using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExchangeData.Models;

[Table("comments")]
public partial class Comment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("create_on", TypeName = "datetime")]
    public DateTime CreateOn { get; set; }

    [Column("student_id")]
    public int StudentId { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("content")]
    [StringLength(255)]
    public string? Content { get; set; }

    [Column("reply_id")]
    public int? ReplyId { get; set; }

    [Column("status")]
    public int? Status { get; set; }

    [Column("modify_at", TypeName = "datetime")]
    public DateTime? ModifyAt { get; set; }

    [Column("imageId")]
    [StringLength(255)]
    public string? ImageId { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Comments")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("Comments")]
    public virtual Student Student { get; set; } = null!;
}
