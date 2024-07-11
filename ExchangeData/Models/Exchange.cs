using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
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

    [Column("send_date", TypeName = "datetime")]
    public DateTime? SendDate { get; set; }

    [Column("receive_date", TypeName = "datetime")]
    public DateTime? ReceiveDate { get; set; }

    [Column("cancel_date", TypeName = "datetime")]
    public DateTime? CancelDate { get; set; }

    [Column("cancel_reason")]
    public string? CancelReason { get; set; }

    [Column("shipCost")]
    public double? ShipCost { get; set; }

    [Column("shipCode")]
    public string? ShipCode { get; set; }

    [Column("shipStatus")]
    public int? ShipStatus { get; set; }

    [ForeignKey("ExchangeId")]
    [InverseProperty("Exchanges")]
    [JsonIgnore]
    public virtual Product? ExchangeNavigation { get; set; } = null!;

    [ForeignKey("TransactionId")]
    [InverseProperty("Exchanges")]
    [JsonIgnore]
    public virtual Transaction? Transaction { get; set; } = null!;
}
