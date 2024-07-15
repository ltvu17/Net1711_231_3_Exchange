

namespace ExchangeWebApp.Models
{
    public class SellDTO
    { 

        public int Id { get; set; }
        public string Payment { get; set; } = null!;
        public int TransactionId { get; set; }

        public int Status { get; set; }

        public double? CashCustomerPay { get; set; }

        public DateTime? CreateOn { get; set; }

        public double? CashBack { get; set; }

        public double? TotalPrice { get; set; }

        public string? Note { get; set; }
        public string? PaymentMethod { get; set; }
        public virtual TransactionDTO Transaction { get; set; } = null!;

    }
}
