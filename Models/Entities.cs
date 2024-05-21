using JtTcc.Models;

namespace JtTcc.Models;

using System;

// Classe para a tabela tb_permissao
public class Pagina
{
    public Pagina()
    {
        Nome = string.Empty;
        // Paginas = new List<PermissaoPaginas>();
    }
    public int Id { get; set; }
    public string Nome { get; set; }
    // public ICollection<PermissaoPaginas> Paginas { get; set; }
}

// Classe para a tabela tb_permissao_funcao
public class PermissaoPaginas
{
    public PermissaoPaginas()
    {
        UsuarioId = default;
        PaginaId = default;
    }
    public int Id { get; set;}
    public int UsuarioId { get; set; }
    public int PaginaId { get; set; }
    // public virtual Pagina Paginas { get; set; } = new Pagina();
}

// // Classe para a tabela tb_funcao
// public class Funcao
// {
//     public int Id { get; set; }
//     public string Sigla { get; set; }
//     public string Nome { get; set; }
//     public string Descricao { get; set; }
//     public bool Administrador { get; set; }
// }

// Classe para a tabela tb_usuario_funcao
public class UsuarioFuncao
{
    public int UsuarioId { get; set; }
    public int FuncaoId { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataAssociacao { get; set; }
}

// Classe para a tabela tb_portao
public class Registro
{
    public Registro()
    {
        Tag = string.Empty;
        Nome = string.Empty;
        Descricao = string.Empty;
        CPF = string.Empty;
        Visitante = default;
        Pedestre = default;
        Ativo = default;
        Pedestre = default;
    }
    public int Id { get; set; }
    public string Tag { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string CPF { get; set; }
    public bool Visitante { get; set; }
    public bool Pedestre { get; set; }
    public int PortaoId { get; set; }
    public int UsuarioId { get; set; } = default;
    public bool Ativo { get; set; }
    public string Celular { get; set; } = string.Empty;
    public DateTime Create { get; set; }
    public string Base64 { get; set; } =string.Empty;
    // public ICollection<Veiculo> Veiculos{ get; set; } = new List<Veiculo>();
    // // public virtual Usuario Usuarios{ get; set; } = new Usuario();
    // public ICollection<TipoEntrada> TipoEntradas { get; set; } = new List<TipoEntrada>();
}

public class TipoEntrada
{
    public int Id { get; set;}  
    public int RegistroId { get; set; }
    public TipoEntradaEnum Tipo { get; set; } = default;
    public DateTime Create { get; set; }

}

// public class Registro
// {
//     public int Id { get; set; }
//     public char Tipo { get; set; }
//     public int PortaoId { get; set; }
//     public DateTime DataRegistro { get; set; }
//     public int PessoaId { get; set; }
//     public int VeiculoId { get; set; }
// }

// Classe para a tabela tb_pessoa
// public class Pessoa
// {
//     public int Id { get; set; }
//     public string Nome { get; set; }
//     public string CPF { get; set; }
//     public string Email { get; set; }
//     public DateTime DataNascimento { get; set; }
// }

// public class Conta
// {
//     public Conta(){
//         CPF = string.Empty;
//         Nome = string.Empty;
//         Celular = string.Empty;
//         funcao = default;
//     }
//     public string CPF { get; set; }
//     public string Nome { get; set; }
//     public string Celular { get; set; }
//     public FuncaoEnum funcao{get;set;}
//     public ICollection<Usuario> Usuarios { get; set; }
// }

// Classe para a tabela tb_usuario
public class Usuario
{
    public Usuario(){
        Login = string.Empty;
        Senha = string.Empty;
        CPF = string.Empty;
        Celular = string.Empty;
        Nome = string.Empty;
        Active = default;
        Status = default;
    }
    public int Id { get; set; }
    public string Login { get; set; }
    public string? Senha { get; set; }
    public string CPF { get; set; }
    public string Nome { get; set; }
    public string Celular { get; set; }
    public bool Active { get; set; }
    public int RegistroId { get; set; }
    public StatusEnum Status { get; set; }
    public DateTime Create { get; set; }
    // public ICollection<Registro> Registros{ get; set; } = new List<Registro>();
    // public ICollection<PermissaoPaginas> Paginas { get; set; } = new List<PermissaoPaginas>();
}

// Classe para a tabela tb_tipo_pessoa
// public class TipoPessoa
// {
//     public int Id { get; set; }
//     public string Sigla { get; set; }
//     public string Descricao { get; set; }
// }

// Classe para a tabela tb_funcionario
// public class Funcionario
// {
//     public int Id { get; set; }
//     public int PessoaTipoId { get; set; }
//     public string CargoNome { get; set; }
//     public string CargoDescricao { get; set; }
// }

// Classe para a tabela tb_pessoa_tipo
// public class PessoaTipo
// {
//     public int Id { get; set; }
//     public int PessoaId { get; set; }
//     public int TipoPessoaId { get; set; }
//     public bool Valido { get; set; }
// }

// Classe para a tabela tb_portao_localizacao
public class PortaoLocalizacao
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
}

// Classe para a tabela tb_veiculo
public class Veiculo
{
    public Veiculo()
    {
        TipoVeiculo = string.Empty;
        Placa = string.Empty;
    }
    public int Id { get; set; }
    public string TipoVeiculo { get; set; }
    public string Placa { get; set; }
    public int RegistroId { get; set; } = default;
}

// // Classe para a tabela tb_veiculo_pessoa
// public class VeiculoPessoa
// {
//     public int VeiculoId { get; set; }
//     public int PessoaId { get; set; }
// }

// // Classe para a tabela tb_tag_pessoa
// public class TagPessoa
// {
//     public int Id { get; set; }
//     public int PessoaId { get; set; }
// }

// // Classe para a tabela tb_morador
// public class Morador
// {
//     public int Id { get; set; }
//     public int PessoaTipoId { get; set; }
//     public int MoradorResponsavelId { get; set; }
// }

// Classe para a tabela tb_visitante
// public class Visitante
// {
//     public int Id { get; set; }
//     public int PessoaTipoId { get; set; }
//     public int PessoaId { get; set; }
//     public int MoradorApartamentoResponsavelId { get; set; }
// }

// Classe para a tabela tb_tipo_veiculo
// public class TipoVeiculo
// {
//     public int Id { get; set; }
//     public string Sigla { get; set; }
//     public string Descricao { get; set; }
// }

// Classe para a tabela tb_tag_veiculo
// public class TagVeiculo
// {
//     public int Id { get; set; }
//     public int VeiculoId { get; set; }
// }

// Classe para a tabela tb_tipo_tag
// public class TipoTag
// {
//     public int Id { get; set; }
//     public string Sigla { get; set; }
//     public string Descricao { get; set; }
// }

// Classe para a tabela tb_tag
// public class Tag
// {
//     public int Id { get; set; }
//     public string Identificacao { get; set; }
//     public int TipoTagId { get; set; }
//     public bool Valida { get; set; }
// }

// // Classe para a tabela tb_endereco
// public class Endereco
// {
//     public int Id { get; set; }
//     public string CEP { get; set; }
//     public string Descricao { get; set; }
// }

// Classe para a tabela tb_bloco
// public class Bloco
// {
//     public int Id { get; set; }
//     public int EnderecoId { get; set; }
//     public string Descricao { get; set; }
//     public string Sigla { get; set; }
// }

// Classe para a tabela tb_apartamento
// public class Apartamento
// {
//     public int Id { get; set; }
//     public int BlocoId { get; set; }
//     public string Descricao { get; set; }
//     public int Vagas { get; set; }
// }

// // Classe para a tabela tb_morador_apartamento
// public class MoradorApartamento
// {
//     public int MoradorId { get; set; }
//     public int ApartamentoId { get; set; }
//     public int MoradorApartamentoId { get; set; }
// }
