using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeData.DTO
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public int Status { get; set; }
        public int StudentId { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime ReportTime { get; set; }
        public double? Rate { get; set; }
        public string Title { get; set; } = null!;
        public string? ContentPost { get; set; }
        public double Price { get; set; }
        public string? ApproveBy { get; set; }
        public DateTime? ApproveDate { get; set; }
        public int CategoryId { get; set; }
    }
}
