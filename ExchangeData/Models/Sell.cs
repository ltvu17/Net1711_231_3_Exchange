using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExchangeData.Models;

[Table("sells")]
public partial class Sell
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("payment")]
    [StringLength(255)]
    public string Payment { get; set; } = null!;

    [Column("transaction_id")]
    public int TransactionId { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [Column("cashCustomerPay")]
    public double? CashCustomerPay { get; set; }

    [Column("createOn", TypeName = "datetime")]
    public DateTime? CreateOn { get; set; }

    [Column("cashBack")]
    public double? CashBack { get; set; }

    [Column("totalPrice")]
    public double? TotalPrice { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [ForeignKey("TransactionId")]
    [InverseProperty("Sells")]
    public virtual Transaction Transaction { get; set; } = null!;
}
