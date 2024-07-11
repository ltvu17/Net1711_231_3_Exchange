using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ExchangeData.Models;

[Table("reports")]
public partial class Report
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("reporter")]
    public int Reporter { get; set; }

    [Column("assignee")]
    public int Assignee { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("report_time", TypeName = "datetime")]
    public DateTime ReportTime { get; set; }

    [Column("reason")]
    [StringLength(255)]
    public string Reason { get; set; } = null!;

    [Column("approve_by")]
    [StringLength(450)]
    public string? ApproveBy { get; set; }

    [Column("approve_time", TypeName = "datetime")]
    public DateTime? ApproveTime { get; set; }

    [Column("reply")]
    [StringLength(255)]
    public string? Reply { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [ForeignKey("ApproveBy")]
    [InverseProperty("Reports")]
    [JsonIgnore]
    public virtual User? ApproveByNavigation { get; set; }

    [ForeignKey("Assignee")]
    [InverseProperty("ReportAssigneeNavigations")]
    [JsonIgnore]
    public virtual Student? AssigneeNavigation { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("Reports")]
    [JsonIgnore]
    public virtual Product? Product { get; set; } = null!;

    [ForeignKey("Reporter")]
    [InverseProperty("ReportReporterNavigations")]
    [JsonIgnore]
    public virtual Student? ReporterNavigation { get; set; } = null!;
}
