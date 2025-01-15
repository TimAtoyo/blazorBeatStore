using System;
using System.Collections.Generic;

namespace EcommerseBlazor.Models;

public partial class Purchase
{
    public int PurchaseID { get; set; }

    public int UserID { get; set; }

    public int BeatID { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public decimal PriceAtPurchase { get; set; }
}
