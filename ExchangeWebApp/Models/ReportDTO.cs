namespace ExchangeWebApp.Models
{
    public class ReportDTO
    {
        public int Id { get; set; }

        public int Reporter { get; set; }

        public int Assignee { get; set; }

        public int ProductId { get; set; }

        public DateTime ReportTime { get; set; }

        public string Reason { get; set; } = null!;

        public string? ApproveBy { get; set; }

        public DateTime? ApproveTime { get; set; }

        public string? Reply { get; set; }

        public int Status { get; set; }
    }
}
