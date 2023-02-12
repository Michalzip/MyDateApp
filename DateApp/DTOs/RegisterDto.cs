using System;
using System.ComponentModel.DataAnnotations;

namespace App.DTOs
{
    public class RegisterDto
    {

        [Required] public string? UserName { get; set; }
        [Required] public string? Email { get; set; }
        [Required] public string? Password { get; set; }


    }
}