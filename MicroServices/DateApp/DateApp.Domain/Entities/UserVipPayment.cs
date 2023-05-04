namespace Domain.Entities
{
    public class UserVipPayment
    {
        public int Id;
        public int DaysCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}