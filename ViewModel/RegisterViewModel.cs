using System.ComponentModel.DataAnnotations;

public class RegisterMoradorViewModel
{
    public RegisterMoradorViewModel()
    {
        CPF = string.Empty;
        Apt = default;
        Veiculo = string.Empty;
        Placa = string.Empty;
        Tag = string.Empty;
        TipoEntrada = default;
        Observacao = string.Empty;
    }

    [Required(ErrorMessage = "Obrigatório")]
    public string CPF {get; set;}

     [Required(ErrorMessage = "Obrigatório")]
    public int Apt {get; set;}

    public string Veiculo {get; set;}
    public string Placa {get; set;}

    [Required(ErrorMessage = "Obrigatório")]
    public string Tag { get; set; }
    public string Observacao { get; set; }
    public TipoEntradaEnum TipoEntrada { get; set; }
    
    [Required(ErrorMessage = "Obrigatório")]
    public bool Pedestre { get; set; }

    public string Base64 { get; set; }
}


public class RegisterVisitanteViewModel
{
    public RegisterVisitanteViewModel()
    {
        CPF = string.Empty;
        Nome = string.Empty;
        Apt = default;
        Veiculo = string.Empty;
        Placa = string.Empty;
        Tag = string.Empty;
        TipoEntrada = default;
        Observacao = string.Empty;
    }

    [Required(ErrorMessage = "Obrigatório")]
    public string CPF {get; set;}

    [Required(ErrorMessage = "Obrigatório")]
    public string Nome {get; set;}

    [Required(ErrorMessage = "Obrigatório")]
    public int Apt {get; set;}
    public string Celular {get; set;}
    public string Veiculo {get; set;}
    public string Placa {get; set;}

    [Required(ErrorMessage = "Obrigatório")]
    public string Tag { get; set; }
    public string Observacao { get; set; }
    public TipoEntradaEnum TipoEntrada { get; set; }
    
    [Required(ErrorMessage = "Obrigatório")]
    public bool Pedestre { get; set; }
    public string Base64 { get; set; }
}


public class QueryEntradaSaidaViewModel
{
    public QueryEntradaSaidaViewModel()
    {
        Pesquisa = string.Empty;
        Inicio = default;
        Final = default;

    }

    [Required(ErrorMessage = "Obrigatório")]
    public string Pesquisa {get; set;}
    public DateTime Inicio { get; set; }
    public DateTime Final { get; set; }
    
}

public class RegisterAprovViewModel
{
    public RegisterAprovViewModel()
    {

        status = default;
    }

    [Required(ErrorMessage = "Obrigatório")]
    public string cpf {get; set;}

    [Required(ErrorMessage = "Obrigatório")]
    public StatusEnum status {get; set;}
    
}