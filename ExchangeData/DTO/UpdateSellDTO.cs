namespace ExchangeWebApi.DTO
{
    public class UpdateSellDTO
    {
        public int Id { get; set; }
        public string Payment { get; set; } = null!;
        public int TransactionId { get; set; }
        public int Status { get; set; }
        public string? Note { get; set; } = null!;
        public double CashCustomerPay { get; set; }

    }
}
