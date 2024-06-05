using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExchangeData.Models;

[Table("company")]
public partial class Company
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("companyname")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Companyname { get; set; }

    [Column("address")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Address { get; set; }

    [Column("email")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("phone")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [Column("activities")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Activities { get; set; }

    [Column("description")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Description { get; set; }

    [Column(TypeName = "text")]
    public string? Note { get; set; }
}
