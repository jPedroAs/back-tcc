
using System.Net;
using System.Security.Cryptography;
using ApiBalada.Services;
using JtTcc.Migrations;
using JtTcc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Parking.ViewModels;

[ApiController]
public class Register : ControllerBase
{
    private readonly Context _context;

    public Register(Context context)
    {
        _context = context;
    }


    [HttpPut("api/register/approve")]
    public async Task<ResponseViewModel> Patch([FromBody] RegisterAprovViewModel model)
    {
        var response = new ResponseViewModel();

        try{
            var user =  await _context.Usuarios.FirstAsync(x => x.CPF == model.cpf);
            if (user == null)
                return response.GetResponse("Usuário não existe", HttpStatusCode.BadRequest);

            user.Active = model.status == StatusEnum.Aprovado ? true : false;
            user.Status = model.status;
            await _context.SaveChangesAsync();
            return response.GetResponse("Status do Usuário alterado com sucesso.", HttpStatusCode.OK);
        }
        catch{
            return response.GetResponse("Erro Interno", HttpStatusCode.BadRequest);
        }
    }

     [HttpGet("api/register/approve/buscar")]
    public async Task<ResponseViewModel> Get()
    {
        var response = new ResponseViewModel();

        try{
            var user =  await _context.Usuarios.Select(x => new {x.Nome, x.CPF, x.Create, x.Status}).ToListAsync();
            return response.GetResponse("Adicionado com sucesso.", HttpStatusCode.OK, user);
        }
        catch{
            return response.GetResponse("Erro Interno", HttpStatusCode.BadRequest);
        }
    }

     [HttpGet("api/register/buscar")]
    public async Task<ResponseViewModel> GetCpf([FromQuery] string CPF)
    {
        var response = new ResponseViewModel();

        try{
            var user =  await _context.Registros.Where(w => w.CPF == CPF).Select(s => s.Nome).FirstOrDefaultAsync();
            if(user == null)
            {
                var regi = await _context.Usuarios.Where(w => w.CPF == CPF).Select(s => s.Nome).FirstOrDefaultAsync();
                if(regi == null)
                    return response.GetResponse("CPF não encontrado.", HttpStatusCode.BadRequest);
                return response.GetResponse("Consulta realizada com sucesso.", HttpStatusCode.OK, regi);
            }
            return response.GetResponse("Consulta realizada com sucesso.", HttpStatusCode.OK, user);
        }
        catch{
            return response.GetResponse("Erro Interno", HttpStatusCode.BadRequest);
        }
    }

    [HttpPost("api/register/morador")]
    public async Task<ResponseViewModel> Post([FromBody] RegisterMoradorViewModel model)
    {
        var response = new ResponseViewModel();

        try{
            var user = await _context.Usuarios.Where(x => x.CPF == model.CPF).FirstOrDefaultAsync();
            if(user == null)
                 return response.GetResponse("CPF não foi encontrado", HttpStatusCode.NoContent);
            var rg = await _context.Registros.Where(x => x.UsuarioId == user.Id).FirstOrDefaultAsync();
            if(rg != null)
            {
                var tp = await _context.TipoEntradas.Where(x => x.RegistroId == rg.Id && x.Tipo != TipoEntradaEnum.Saida).FirstOrDefaultAsync();
                if(tp == null)
                    return response.GetResponse("CPF já registrado", HttpStatusCode.NoContent);
            }

            var morador = new Registro
            {
                Tag = model.Tag,
                Nome = user.Nome,
                CPF = user.CPF,
                Visitante = false,
                UsuarioId = user.Id,
                Pedestre = model.Pedestre,
                PortaoId = model.Apt,
                Ativo = true,
                Create = DateTime.Now,
                Descricao = model.Observacao,
                Base64 = model.Base64
            };
            await _context.Registros.AddAsync(morador);
            await _context.SaveChangesAsync();

            user.RegistroId = morador.Id;
            _context.Usuarios.Update(user);

            if(model.Pedestre is not true)
            {
                var veiculo = new Veiculo
                {
                    TipoVeiculo = model.Veiculo,
                    Placa = model.Placa,
                    RegistroId = morador.Id
                };

                await _context.Veiculos.AddAsync(veiculo);
            }

            var tipo = new TipoEntrada
            {
                RegistroId = morador.Id,
                Tipo = model.TipoEntrada,
                Create = DateTime.Now
            };
            await _context.TipoEntradas.AddAsync(tipo);

            await _context.SaveChangesAsync();
            return response.GetResponse("Registrado com sucesso", HttpStatusCode.OK);
        }
        catch{
            return response.GetResponse("Erro Interno", HttpStatusCode.BadRequest);
        }
    }

    [HttpPost("api/register/visitante")]
    public async Task<ResponseViewModel> Visitante([FromBody] RegisterVisitanteViewModel model)
    {
        var response = new ResponseViewModel();

        try{
            var register = await _context.Registros.Where(x => x.CPF == model.CPF).FirstOrDefaultAsync();

            if(register != null)
            {
                var tp = await _context.TipoEntradas.Where(x => x.RegistroId == register.Id && x.Tipo != TipoEntradaEnum.Saida).FirstOrDefaultAsync();
                if(tp != null)
                    return response.GetResponse("CPF já cadastrado com o tipo Entrada", HttpStatusCode.BadRequest);
            }
          
            var visitante = new Registro
            {
                Tag = model.Tag,
                Nome = model.Nome,
                CPF = model.CPF,
                Visitante = false,
                Celular = model.Celular,
                UsuarioId = 0,
                Pedestre = model.Pedestre,
                PortaoId = model.Apt,
                Ativo = true,
                Create = DateTime.Now,
                Descricao = model.Observacao,
                Base64 = model.Base64
            };
            await _context.Registros.AddAsync(visitante);
            await _context.SaveChangesAsync();

             if(model.Pedestre == false)
            {
                var veiculo = new Veiculo
                {
                    TipoVeiculo = model.Veiculo,
                    Placa = model.Placa
                };

                await _context.Veiculos.AddAsync(veiculo);
            }

            var tipo = new TipoEntrada
            {
                RegistroId = visitante.Id,
                Tipo = model.TipoEntrada,
                Create = DateTime.Now
            };
            await _context.TipoEntradas.AddAsync(tipo);

            await _context.SaveChangesAsync();
            return response.GetResponse("Registrado com sucesso", HttpStatusCode.OK);
        }
        catch{
            return response.GetResponse("Erro Interno", HttpStatusCode.BadRequest);
        }
    }

     [HttpPost("api/register/query/es")]
    public async Task<ResponseViewModel> GetEntrada([FromBody] QueryEntradaSaidaViewModel model)
    {
        var response = new ResponseViewModel();
        var veiculo =new Veiculo();
        var dto = new List<dynamic>();
        try{
            var user =  await _context.Registros
                        .Where(w => w.CPF == model.Pesquisa || w.Tag == model.Pesquisa || 
                        w.Create >= model.Inicio && w.Create <= model.Final).ToListAsync();
            
            if(user == null)
                return response.GetResponse("Pesquisa não encontrada.", HttpStatusCode.OK);  
            foreach(var it in user){

                if(it.Pedestre != true){
                    veiculo = await _context.Veiculos.Where(x => x.RegistroId == it.Id).FirstOrDefaultAsync();
                    if(veiculo == null)
                        return response.GetResponse("Veículo não cadastrado.", HttpStatusCode.BadRequest);
                }
                var portao = await _context.PortoesLocalizacao.FirstOrDefaultAsync(x => x.Id == it.PortaoId);
                if(portao == null)
                    return response.GetResponse("Portao não cadastrado.", HttpStatusCode.BadRequest);
                var tipo = await _context.TipoEntradas.FirstOrDefaultAsync(x => x.Id == it.PortaoId && x.Tipo == TipoEntradaEnum.Entrada);
                if(tipo == null)
                    return response.GetResponse("Portao não cadastrado.", HttpStatusCode.BadRequest);
                var reg = new {it, veiculo.TipoVeiculo, tipo.Tipo, portao.Nome};
                dto.Add(reg);
            }
            return response.GetResponse("Adicionado com sucesso.", HttpStatusCode.OK, dto);
        }
        catch{
            return response.GetResponse("Erro Interno", HttpStatusCode.BadRequest);
        }
    }
     [HttpGet("api/register/portao")]
    public async Task<ResponseViewModel> GetPortao()
    {
        var response = new ResponseViewModel();

        try{
            var portao = await _context.PortoesLocalizacao.ToListAsync();
            return response.GetResponse("Sucesso.", HttpStatusCode.OK, portao);
        }
        catch{
            return response.GetResponse("Erro Interno", HttpStatusCode.BadRequest);
        }
    }

     [HttpGet("api/register/busca-mora")]
    public async Task<ResponseViewModel> GetMor([FromQuery] string cpf)
    {
        var response = new ResponseViewModel();
        var veiculo = new Veiculo();
        var tipo = new PortaoLocalizacao();

        try{
            var user = await _context.Usuarios.FirstOrDefaultAsync(x => x.CPF == cpf);
            if(user == null)    
                return response.GetResponse("Morador Não Encontrado.", HttpStatusCode.NoContent);
            var us = await _context.Registros.FirstOrDefaultAsync(x => x.UsuarioId == user.Id);
            if(us != null)
            {
                if(us.Pedestre != true){
                    veiculo = await _context.Veiculos.Where(x => x.RegistroId == us.Id).FirstOrDefaultAsync();
                    if(veiculo == null)
                        return response.GetResponse("Veículo não cadastrado.", HttpStatusCode.BadRequest);
                }
                tipo = await _context.PortoesLocalizacao.FirstOrDefaultAsync(x => x.Id == us.PortaoId);
                if(tipo == null)
                    return response.GetResponse("Portao não cadastrado.", HttpStatusCode.BadRequest);

                var userDto = new {us.Tag, us.Base64, user,tipo, veiculo};
                return response.GetResponse("Achado com sucesso.", HttpStatusCode.OK, userDto);
            }
            return response.GetResponse("Achado com sucesso.", HttpStatusCode.OK, new {user, tipo, veiculo});
        }
        catch{
            return response.GetResponse("Erro Interno", HttpStatusCode.BadRequest);
        }
    }


      [HttpGet("api/register/busca-visi")]
    public async Task<ResponseViewModel> GetVis([FromQuery] string cpf)
    {
        var response = new ResponseViewModel();
        var veiculo = new Veiculo();

        try{
            var user = await _context.Registros.FirstOrDefaultAsync(x => x.CPF == cpf);
            if(user == null)    
                return response.GetResponse("Morador Não Encontrado.", HttpStatusCode.NoContent);
            if(user.Pedestre != true){
                veiculo = await _context.Veiculos.Where(x => x.RegistroId == user.Id).FirstOrDefaultAsync();
                if(veiculo == null)
                    return response.GetResponse("Veículo não cadastrado.", HttpStatusCode.BadRequest);
            }
            var tipo = await _context.PortoesLocalizacao.FirstOrDefaultAsync(x => x.Id == user.PortaoId);
            if(tipo == null)
                return response.GetResponse("Portao não cadastrado.", HttpStatusCode.BadRequest);
            
            var userDto = new { user, tipo, veiculo};
            return response.GetResponse("Achado com sucesso.", HttpStatusCode.OK, userDto);
        }
        catch{
            return response.GetResponse("Erro Interno", HttpStatusCode.BadRequest);
        }
    }
};