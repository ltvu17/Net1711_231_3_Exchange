using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExchangeWebApp.Models
{
    public class CommentDTO
    {
        public int Id { get; set; }

        public DateTime CreateOn { get; set; } = DateTime.Now;

        public int StudentId { get; set; }

        public int ProductId { get; set; }

        [StringLength(255)]
        public string? Content { get; set; }

        public int? ReplyId { get; set; }

        public int? Status { get; set; }

        public DateTime? ModifyAt { get; set; }  

        [StringLength(255)]
        public string? ImageId { get; set; }
    }
}
