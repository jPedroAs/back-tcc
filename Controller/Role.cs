
using System.Net;
using ApiBalada.Services;
using JtTcc.Models;
using Microsoft.AspNetCore.Mvc;
using Parking.ViewModels;

[ApiController]
public class Role : ControllerBase
{
    private readonly Context _context;

    public Role(Context context)
    {
        _context = context;
    }


    [HttpPost("api/pagina")]
    public async Task<ResponseViewModel> Post()
    {
        var response = new ResponseViewModel();

        var siglas =  new List<string>() { "Visitante", "Solicitações", "Morador", "Entrada/Saída"};
        
        foreach (var sig in siglas)
        {
            var roles = new Pagina{
                Nome = sig
            };

            await _context.Paginas.AddAsync(roles);
        }

        await _context.SaveChangesAsync();
        return response.GetResponse("Adicionado com sucesso.", HttpStatusCode.OK);
    }


     [HttpPost("api/portao")]
    public async Task<ResponseViewModel> PostPortao()
    {
        var response = new ResponseViewModel();

        var siglas =  new List<string>() { "Portão 1", "Portão 2"};
        
        foreach (var sig in siglas)
        {
            var roles = new PortaoLocalizacao{
                Nome = sig
            };

            await _context.PortoesLocalizacao.AddAsync(roles);
        }

        await _context.SaveChangesAsync();
        return response.GetResponse("Adicionado com sucesso.", HttpStatusCode.OK);
    }
}