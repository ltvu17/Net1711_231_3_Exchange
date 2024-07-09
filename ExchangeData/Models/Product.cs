using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ExchangeData.Models;

[Table("products")]
public partial class Product
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [Column("student_id")]
    public int StudentId { get; set; }

    [Column("create_on", TypeName = "datetime")]
    public DateTime CreateOn { get; set; }

    [Column("report_time", TypeName = "datetime")]
    public DateTime? ReportTime { get; set; } = DateTime.Now.AddDays(1);

    [Column("rate")]
    public double? Rate { get; set; }

    [Column("title")]
    [StringLength(255)]
    public string Title { get; set; } = null!;

    [Column("content_post")]
    [StringLength(255)]
    public string? ContentPost { get; set; }

    [Column("price")]
    public double Price { get; set; }

    [Column("approve_by")]
    [StringLength(450)]
    public string? ApproveBy { get; set; }

    [Column("approve_date", TypeName = "datetime")]
    public DateTime? ApproveDate { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    [Column("img_key")]
    public string? ImgKey { get; set; }

    [ForeignKey("ApproveBy")]
    [InverseProperty("Products")]
    [JsonIgnore]
    public virtual User? ApproveByNavigation { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    [JsonIgnore]
    public virtual Category? Category { get; set; } = null!;

    [InverseProperty("Product")]
    [JsonIgnore]
    public virtual ICollection<Comment>? Comments { get; set; } = new List<Comment>();

    [InverseProperty("ExchangeNavigation")]
    [JsonIgnore]
    public virtual ICollection<Exchange>? Exchanges { get; set; } = new List<Exchange>();

    [InverseProperty("Product")]
    [JsonIgnore]
    public virtual ICollection<Report>? Reports { get; set; } = new List<Report>();

    [ForeignKey("StudentId")]
    [JsonIgnore]
    [InverseProperty("Products")]
    public virtual Student? Student { get; set; } = null!;

    [InverseProperty("Product")]
    [JsonIgnore]
    public virtual ICollection<Transaction>? Transactions { get; set; } = new List<Transaction>();
}
