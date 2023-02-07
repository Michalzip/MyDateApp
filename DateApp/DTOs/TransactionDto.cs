using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public class TransactionDto
    {
        public string? Currency { get; set; }
        public string? Amount { get; set; }
        public DateTime createdAt { get; set; }

    }
}