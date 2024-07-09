using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeData.DTO
{
    public class CreateTransaction
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Note { get; set; }
        public double Price { get; set; }
        public int StudentBuy {  get; set; }
        public string? TypeTransactions { get; set; }

    }
}
