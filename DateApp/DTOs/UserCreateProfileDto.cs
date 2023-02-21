using System;
using System.ComponentModel.DataAnnotations;
using Api.Entities;

namespace Api.DTOs
{
    public class UserCreateProfileDto
    {

        [Required] public string? FirstName { get; set; }
        [Required] public string? LastName { get; set; }
        public string? PhotoUrl { get; set; }

    }
}

