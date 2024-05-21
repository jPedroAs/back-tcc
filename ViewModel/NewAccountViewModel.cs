using System.ComponentModel.DataAnnotations;

public class NewAccountViewModel
{
    public NewAccountViewModel()
    {
        CPF = string.Empty;
        Nome = string.Empty;
        Celular = string.Empty;
        Funcao = default;
        Login = string.Empty;
        Senha = string.Empty;
    }

    [Required(ErrorMessage = "Obrigatório")]
    public string CPF {get; set;}

    [Required(ErrorMessage = "Obrigatório")]
    public string Nome {get; set;}

    [Required(ErrorMessage = "Obrigatório")]
    public string Celular {get; set;}

    [Required(ErrorMessage = "Obrigatório")]
    public FuncaoEnum Funcao {get; set;}

    [Required(ErrorMessage = "Obrigatório")]
    [EmailAddress(ErrorMessage = "Necessário um email válido")]  
    public string Login {get; set;}

    [Required(ErrorMessage = "Senha é Obrigatório e deve ter mais de 8 caracteres")]
    [StringLength(20, MinimumLength = 8)]
    public string Senha { get; set; }
}


public class EmailViewlModel
{
    public string email { get; set; } = string.Empty;
}