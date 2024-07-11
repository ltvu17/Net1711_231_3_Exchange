using System.ComponentModel.DataAnnotations.Schema;

namespace ExchangeWebApp.Models
{
    public class ExchangeDTO
    {
        public int Id { get; set; }
        public int ExchangeId { get; set; }
        public int TransactionId { get; set; }
        public int Status { get; set; }
        public DateTime? SendDate { get; set; }

        public DateTime? ReceiveDate { get; set; }

        public DateTime? CancelDate { get; set; }

        public string? CancelReason { get; set; }

        public double? ShipCost { get; set; }

        public string? ShipCode { get; set; }

        public int? ShipStatus { get; set; }

    }
}
