using System;
using System.Collections.Generic;

namespace EcommerseBlazor.Data;

public partial class Beat
{
    public int BeatId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Genre { get; set; }

    public decimal Price { get; set; }

    public string FilePath { get; set; } = null!;

    public string? CoverImagePath { get; set; }

    public int UploadedBy { get; set; }

    public DateTime UploadDate { get; set; }

    public int GenreID { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Genre? GenreNavigation { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual User UploadedByNavigation { get; set; } = null!;
}
