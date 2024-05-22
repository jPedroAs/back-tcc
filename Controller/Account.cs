
using System.Net;
using System.Net.Mail;
using ApiBalada.Services;
using JtTcc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking.ViewModels;
using SQLitePCL;

[ApiController]
public class Account : ControllerBase
{
    private readonly Context _context;
    private readonly TokenService _tokenService;

    public Account(Context context,
                TokenService tokenService){
        _context = context;
        _tokenService = tokenService;
    }


    [HttpPost("api/accounts/login")]
    public async Task<ResponseViewModel> Entrar([FromBody] LoginViewModel req )
    {
        var response = new ResponseViewModel();

        try
        {   
            var login = await _context.Usuarios.FirstOrDefaultAsync(x => x.Login == req.Login && x.Senha == req.Senha);
            if (login == null)
                return  response.GetResponse("E-mail ou Senha errada!", HttpStatusCode.NoContent);

            if(login.Active != true)
                return  response.GetResponse("Usuário não Aprovado!", HttpStatusCode.NoContent);

            var pag = await _context.PermissaoPaginas.Where(x => x.UsuarioId == login.Id).ToListAsync();
            var pnm = new List<string>();
            foreach(var p in pag)
            {
                var nm = await _context.Paginas.Where(x => x.Id == p.PaginaId).FirstOrDefaultAsync();
                pnm.Add(nm.Nome);
            }

            var token = _tokenService.CreateToken(login, pnm);
            return response.GetResponse("Login com sucesso.", HttpStatusCode.OK, token);

        }
        catch
        {
            return response.GetResponse("Deu Ruim", HttpStatusCode.BadRequest);
        }
    }

    [HttpPost("api/account/newaccount")]
     public async Task<ResponseViewModel> Post([FromBody] NewAccountViewModel model)
    {
        var response = new ResponseViewModel();

        try
        {   
            var soli = await _context.Usuarios.FirstOrDefaultAsync(x => x.CPF == model.CPF) ;
            if(soli is not null)
                return response.GetResponse("Já foi solicitada uma conta para esse CPF, verificar com o Admin", HttpStatusCode.BadRequest);
            var cadastro = new Usuario 
            {
                CPF = model.CPF,
                Login = model.Login,
                Senha = model.Senha,
                Celular = model.Celular,
                Nome = model.Nome,
                Active = false,
                Status = StatusEnum.Pendente,
                Create = DateTime.Now
                
            };
            await _context.Usuarios.AddAsync(cadastro);
            await _context.SaveChangesAsync();

            var func = new PermissaoPaginas();
            var num = new List<int>();
            switch(model.Funcao)
            {
                case FuncaoEnum.Morador:
                   num.Add(1);
                   await PagPermissao(num, cadastro);
                break;
                case FuncaoEnum.Porteiro:
                   num = new List<int> { 1, 3, 4 };
                   await PagPermissao(num, cadastro);
                break;
                case FuncaoEnum.Admin:
                   num = new List<int> { 1, 2, 3 , 4 };
                   await PagPermissao(num, cadastro);
                break;
            }

            await _context.SaveChangesAsync();
            return response.GetResponse("Registrado com sucesso.", HttpStatusCode.OK, cadastro.Id);
        }
        catch
        {
            return response.GetResponse("Deu Ruim", HttpStatusCode.BadRequest);
        }
    }

    private async Task<bool> PagPermissao(List<int> number, Usuario user)
    {
        var pag = await _context.Paginas.ToListAsync();
        for(int i = 0; i < pag.Count();i++)
        {   
            var p = pag[i].Id;
            if(number.Contains(p))
            {
              var func = new PermissaoPaginas
                    {
                        UsuarioId = user.Id,
                        PaginaId = p,
                    };
                await _context.PermissaoPaginas.AddAsync(func);
            }
        }
        return true;
    }




        [HttpPost("api/email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailViewlModel emailModel)
        {
            try
            {
                var user = await _context.Usuarios.FirstOrDefaultAsync(x => x.Login == emailModel.email);
                if (user == null)
                    return BadRequest($"Usuário não encotrado {emailModel.email}");
        
                var smtpClient = new SmtpClient("smtp.office365.com",587)
                {
                    Port = 587,
                    Credentials = new NetworkCredential("teodozoeamigosRFID@outlook.com", "Teodozoeamigos"),
                    EnableSsl = true,
                    UseDefaultCredentials=false,

                };
                var guid = Guid.NewGuid();
                var senha = guid.ToString("N").Substring(0,10);
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("teodozoeamigosRFID@outlook.com", "TCC"),
                    Subject = "Gerador de Senha",
                    Body = $"essa é sua senha:{senha}",
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(user.Login);
                user.Senha = senha;

                smtpClient.Send(mailMessage);
                await _context.SaveChangesAsync();
                return Ok("Email enviado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    
}