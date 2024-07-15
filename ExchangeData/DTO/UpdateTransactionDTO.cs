using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public double? Price { get; set; }

        public int? StudentBuy { get; set; }

        [StringLength(255)]
        public string? TypeTransactions { get; set; }

    }
}
