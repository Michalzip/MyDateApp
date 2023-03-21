using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TransactionDto
    {
        public string? Currency { get; set; }
        public string? Amount { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}