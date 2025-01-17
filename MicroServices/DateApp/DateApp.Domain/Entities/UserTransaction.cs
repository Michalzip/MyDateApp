using Domain.Entities;


namespace Domain.Entities
{
    public class UserTransaction
    {
        public int Id;
        public string TransactionId { get; set; }
        public string? Currency { get; set; }
        public string? Amount { get; set; }
        public bool Failed { get; set; }
        public bool Expires { get; set; }
        public bool PendingConfirm { get; set; }
        public bool Success { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual UserProfile? ByUser { get; set; }
    }
}