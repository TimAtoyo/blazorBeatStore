using System;
using System.Collections.Generic;

namespace EcommerseBlazor.Models;

public partial class Beat
{
    public int BeatId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Genre { get; set; }

    public decimal Price { get; set; }

    public string? FilePath { get; set; }

    public string? CoverImagePath { get; set; }

    public string? UploadedBy { get; set; }

    public DateTime UploadDate { get; set; }

    public int GenreId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Genre? GenreNavigation { get; set; }

    public virtual ICollection<Purchase>? Purchases { get; set; } 

    public virtual User? UploadedByNavigation { get; set; }
}
