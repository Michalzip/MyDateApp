using System;
using System.ComponentModel.DataAnnotations;

namespace App.DTOs
{
    public class RegisterDto
    {
        // TODO: implement other properties
        [Required] public string Username { get; set; }
    }
}