using System.ComponentModel.DataAnnotations;

namespace TaskManager.Api.Dtos;

public class RegisterDto
{
    [Required(ErrorMessage = "Podaj nazwę użytkownika.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Nazwa musi mieć od 3 do 50 znaków.")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Podaj e-mail.")]
    [EmailAddress(ErrorMessage = "E-mail jest niepoprawny.")]
    [StringLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Podaj hasło.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Hasło musi mieć min. 6 znaków.")]
    public string Password { get; set; } = string.Empty;
}

public class LoginDto
{
    [Required(ErrorMessage = "Podaj e-mail.")]
    [EmailAddress(ErrorMessage = "E-mail jest niepoprawny.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Podaj hasło.")]
    public string Password { get; set; } = string.Empty;
}

public class AuthResponseDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}
