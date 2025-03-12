using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EcommerseBlazor.Models;

public partial class Beat
{
    [Key]
    [Column("BeatID")]
    public int BeatId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    [StringLength(50)]
    public string? Genre { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [StringLength(255)]
    public string FilePath { get; set; } = null!;

    [StringLength(255)]
    public string? CoverImagePath { get; set; }

    public int UploadedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UploadDate { get; set; }

    [Column("GenreID")]
    public int? GenreId { get; set; }

    public bool? IsDeleted { get; set; }

    [Column("BPM")]
    public int? Bpm { get; set; }

    [ForeignKey("GenreId")]
    [InverseProperty("Beats")]
    public virtual Genre? GenreNavigation { get; set; }

    [InverseProperty("Beat")]
    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    [ForeignKey("UploadedBy")]
    [InverseProperty("Beats")]
    public virtual User UploadedByNavigation { get; set; } = null!;
}
