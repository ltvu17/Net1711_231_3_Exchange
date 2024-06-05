using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExchangeData.Models;

[Table("users")]
public partial class User
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("name")]
    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("password")]
    [StringLength(255)]
    public string Password { get; set; } = null!;

    [Column("role")]
    [StringLength(10)]
    public string Role { get; set; } = null!;

    [InverseProperty("ApproveByNavigation")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    [InverseProperty("ApproveByNavigation")]
    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    [InverseProperty("User")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
