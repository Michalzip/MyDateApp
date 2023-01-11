namespace Api.Entities
{
    public class UserProfile
    {
        public string? Id;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? PhotoUrl { get; set; }
        public virtual ICollection<UserLike>? SendedLikes { get; set; }
        public virtual ICollection<UserLike>? ReceivedLikes { get; set; }
        public virtual ICollection<UserMessage>? SendedMessages { get; set; }
        public virtual ICollection<UserMessage>? ReceivedMessages { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}

