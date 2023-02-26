using System;
using System;
using System.ComponentModel.DataAnnotations;
namespace Api.DTOs
{
    public class UserProfileDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? PhotoUrl { get; set; }

    }
}

