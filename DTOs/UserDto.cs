using System;
using System.ComponentModel.DataAnnotations;

namespace App.DTOs
{
	public class UserDto
	{


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? UserAvatar { get; set; }

        public DateTime? UpdatedAt { get; set; }


    }
}

