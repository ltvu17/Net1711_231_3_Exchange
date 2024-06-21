using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExchangeData.Models;

[Table("students")]
public partial class Student
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("address")]
    [StringLength(255)]
    public string? Address { get; set; }

    [Column("phone")]
    [StringLength(10)]
    public string? Phone { get; set; }

    [Column("rate")]
    public double? Rate { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [Column("user_id")]
    [StringLength(450)]
    public string UserId { get; set; } = null!;

    public int? TotalPost { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InactiveIn { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? InactiveReason { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? SeftDescription { get; set; }

    [StringLength(450)]
    public string? Images { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    [InverseProperty("Student")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    [InverseProperty("AssigneeNavigation")]
    public virtual ICollection<Report> ReportAssigneeNavigations { get; set; } = new List<Report>();

    [InverseProperty("ReporterNavigation")]
    public virtual ICollection<Report> ReportReporterNavigations { get; set; } = new List<Report>();

    [ForeignKey("UserId")]
    [InverseProperty("Students")]
    public virtual User User { get; set; } = null!;
}
