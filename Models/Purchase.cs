using System;
using System.Collections.Generic;

namespace EcommerseBlazor.Models;

public partial class Purchase
{
    public int PurchaseId { get; set; }

    public int UserId { get; set; }

    public int BeatId { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public decimal PriceAtPurchase { get; set; }

    public virtual Beat Beat { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
