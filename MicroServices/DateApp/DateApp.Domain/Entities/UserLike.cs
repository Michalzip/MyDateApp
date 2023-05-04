namespace Domain.Entities
{
    public class UserLike
    {
        public int Id;
        public virtual UserProfile? ByUser { get; set; }
        public virtual UserProfile? ToUser { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

