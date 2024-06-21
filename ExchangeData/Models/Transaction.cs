using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExchangeData.Models;

[Table("transactions")]
public partial class Transaction
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column(TypeName = "text")]
    public string? Note { get; set; }

    public double? Price { get; set; }

    [Column("createAt", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [Column("studentBuy")]
    public int? StudentBuy { get; set; }

    [Column("totalPrice")]
    public double? TotalPrice { get; set; }

    [Column("typeTransactions")]
    [StringLength(255)]
    public string? TypeTransactions { get; set; }

    [InverseProperty("Transaction")]
    public virtual ICollection<Exchange> Exchanges { get; set; } = new List<Exchange>();

    [ForeignKey("ProductId")]
    [InverseProperty("Transactions")]
    public virtual Product Product { get; set; } = null!;

    [InverseProperty("Transaction")]
    public virtual ICollection<Sell> Sells { get; set; } = new List<Sell>();
}
