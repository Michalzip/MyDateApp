using System;
using System;
using System.ComponentModel.DataAnnotations;
namespace Api.DTOs
{
	public class UserGetProfileDto
	{



        [Required] public string? FirstName { get; set; }
        [Required] public string? LastName { get; set; }
        //[Required] public string? UserName { get; set; }
        public string? PhotoUrl { get; set; }


    }
}

