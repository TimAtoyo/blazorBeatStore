using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EcommerseBlazor.Models;

public partial class Purchase
{
    [Key]
    [Column("PurchaseID")]
    public int PurchaseId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column("BeatID")]
    public int BeatId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PurchaseDate { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal PriceAtPurchase { get; set; }

    [ForeignKey("BeatId")]
    [InverseProperty("Purchases")]
    public virtual Beat Beat { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Purchases")]
    public virtual User User { get; set; } = null!;
}
