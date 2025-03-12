using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EcommerseBlazor.Models;

[Index("Username", Name = "UQ__Users__536C85E47903314B", IsUnique = true)]
[Index("Email", Name = "UQ__Users__A9D10534B6C89CC6", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(50)]
    public string Username { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    [StringLength(20)]
    public string Role { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    [InverseProperty("Admin")]
    public virtual ICollection<AdminLog> AdminLogs { get; set; } = new List<AdminLog>();

    [InverseProperty("UploadedByNavigation")]
    public virtual ICollection<Beat> Beats { get; set; } = new List<Beat>();

    [InverseProperty("User")]
    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
