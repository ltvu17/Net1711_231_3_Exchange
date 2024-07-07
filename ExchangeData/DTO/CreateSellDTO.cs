namespace ExchangeWebApi.DTO
{
    public class CreateSellDTO
    {
        public string Payment { get; set; } = null!;
        public int TransactionId { get; set; }
        public string? Note { get; set; } = null!;
        public double CashCustomerPay { get; set; }

    }
}
