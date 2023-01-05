using System;
using System.Text.Json.Serialization;
namespace Api.Entities
{
	public class UserMessage
	{

        public int IdMessage;

        public UserProfile? ByUserMessage { get; set; }

        public  UserProfile? ToUserMessage { get; set; }

        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

      
      

    
    }
}

