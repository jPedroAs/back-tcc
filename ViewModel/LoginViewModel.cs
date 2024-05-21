using System.ComponentModel.DataAnnotations;

namespace Parking.ViewModels;

public class LoginViewModel
{
    public LoginViewModel()
    {
        Login = string.Empty;
        Senha = string.Empty;
    }

    [Required(ErrorMessage = "Obrigatório")]
    [EmailAddress(ErrorMessage = "Necessário um email válido")]  
    public string Login {get; set;}

    [Required(ErrorMessage = "Senha é Obrigatório e deve ter mais de 8 caracteres")]
    [StringLength(20, MinimumLength = 8)]
    public string Senha { get; set; }
}