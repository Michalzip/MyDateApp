using System;
namespace Api.Entities
{
	public class UserProfile
	{
        public int UserId;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? PhotoUrl { get; set; }
        public ICollection<UserPost>? PostsUser { get; set; }
        public ICollection<UserComment>? CommentsByUsers { get; set; }
        public ICollection<UserComment>? CommentsFromAnotherUsers { get; set; }
        public ICollection<UserLike>? LikedByUsers { get; set; }
        public ICollection<UserLike>? LikedUsers { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}

