using System;
using System.Text.Json.Serialization;
namespace Api.Entities
{
    public class UserMessage
    {
        public int Id;
        public virtual UserProfile? ByUser { get; set; }
        public virtual UserProfile? ToUser { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}

