using System;
using System.Text.Json.Serialization;
namespace Api.Entities
{
	public class UserMessage
	{

        public int IdMessage;

        public virtual UserProfile? ByUserMessage { get; set; }

        public virtual UserProfile? ToUserMessage { get; set; }

        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

      
      

    
    }
}

