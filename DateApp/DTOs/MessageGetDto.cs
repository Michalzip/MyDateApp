using System;
 using System.ComponentModel.DataAnnotations;
namespace Api.DTOs
{
	public class MessageGetDto
	{
         public string? Sender { get; set; }
         public string? Receiver { get; set; }
        public string ? Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

