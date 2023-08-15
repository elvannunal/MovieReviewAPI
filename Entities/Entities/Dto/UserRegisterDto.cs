using System.ComponentModel.DataAnnotations;

namespace Entities.Dto;

public class UserRegisterDto
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required(ErrorMessage = "Username is required.")]

    public string Username { get; set; }
    [Required(ErrorMessage = "Password is required.")]

    public string Password { get; set; }
    public ICollection<string>? Roles { get; init; }

}