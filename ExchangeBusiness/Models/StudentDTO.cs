using ExchangeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeBusiness.Models
{
    public class StudentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public double? Rate { get; set; }

        public int Status { get; set; }

        public string UserId { get; set; } = null!;
        // add column here
        public string? SeftDescription { get; set; } = null!;
        public int? TotalPost { get; set; } = 0;
        public DateTime? CreatedDate { get; set; }
        public DateTime? InactiveIn { get; set; }
        public string? InactiveReason { get; set; }
        public string? Images { get; set; }
    }
}
