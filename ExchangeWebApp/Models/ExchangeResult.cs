namespace ExchangeWebApp.Models
{
        public interface IExchangeResult
        {
            int Status { get; set; }
            string? Message { get; set; }
            object? Data { get; set; }
        }
        public class ExchangeResult : IExchangeResult
        {
            public int Status { get; set; }
            public string? Message { get; set; }
            public object? Data { get; set; }

            public ExchangeResult()
            {
                Status = -1;
                Message = "Action fail";
            }

            public ExchangeResult(int status, string message)
            {
                Status = status;
                Message = message;
            }

            public ExchangeResult(int status, string message, object data)
            {
                Status = status;
                Message = message;
                Data = data;
            }
        
        }
}
