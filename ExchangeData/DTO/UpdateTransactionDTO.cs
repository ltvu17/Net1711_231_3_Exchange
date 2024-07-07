using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeData.DTO
{
    public class UpdateTransactionDTO
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Note { get; set; }
        public double Price { get; set; }
        public string? TypeTransactions { get; set; }

    }
}
