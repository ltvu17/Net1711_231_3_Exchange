namespace ExchangeWebApi.DTO
{
    public class UpdateSellDTO
    {
        public int Id { get; set; }
        public string Payment { get; set; } = null!;
        public int TransactionId { get; set; }

        public int Status { get; set; }

        public double? CashCustomerPay { get; set; }

        public double? TotalPrice { get; set; }

        public string? Note { get; set; }
        public string? PaymentMethod { get; set; }


    }
}
