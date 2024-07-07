using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExchangeWebApp.Models
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public int Status { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string? Note { get; set; }

        public double? Price { get; set; }

        public DateTime? CreateAt { get; set; }

        public int? StudentBuy { get; set; }

        public double? TotalPrice { get; set; }

        [StringLength(255)]
        public string? TypeTransactions { get; set; }
        public virtual ProductDTO Product { get; set; } = null!;
    }
}
