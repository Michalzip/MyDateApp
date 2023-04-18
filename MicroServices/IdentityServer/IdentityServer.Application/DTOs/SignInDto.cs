using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Application.DTOs
{
    public class SignInDto
    {
        [Required] public string? UserName { get; set; }
        [Required] public string? Password { get; set; }
    }
}