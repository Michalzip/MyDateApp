using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Application.DTOs
{
    public class SignUpDto
    {
        [Required] public string? UserName { get; set; }
        [Required] public string? Email { get; set; }
        [Required] public string? Password { get; set; }
    }
}