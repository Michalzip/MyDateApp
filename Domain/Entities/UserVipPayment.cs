using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Api.Entities
{
    public class UserVipPayment 
    {
        public int Id;
        public int DaysCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}