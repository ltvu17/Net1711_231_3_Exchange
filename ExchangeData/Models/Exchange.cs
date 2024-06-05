using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExchangeData.Models;

[Table("exchanges")]
public partial class Exchange
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("exchange_id")]
    public int ExchangeId { get; set; }

    [Column("transaction_id")]
    public int TransactionId { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [ForeignKey("ExchangeId")]
    [InverseProperty("Exchanges")]
    public virtual Product ExchangeNavigation { get; set; } = null!;

    [ForeignKey("TransactionId")]
    [InverseProperty("Exchanges")]
    public virtual Transaction Transaction { get; set; } = null!;
}
