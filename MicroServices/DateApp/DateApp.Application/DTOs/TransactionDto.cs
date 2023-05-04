namespace Application.DTOs
{
    public class TransactionDto
    {
        public string? Currency { get; set; }
        public string? Amount { get; set; }
        public string? ByUser { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}