using System;
namespace Api.Entities
{
	public class UserComment
	{

        public int IdComment;

        public UserProfile? CommentedByUser { get; set; }
        public UserProfile? CommentedToUser { get; set; }

        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

      
      

    
    }
}

