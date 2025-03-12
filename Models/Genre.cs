using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EcommerseBlazor.Models;

[Index("GenreName", Name = "UQ__Genres__BBE1C339BD7F8AD6", IsUnique = true)]
public partial class Genre
{
    [Key]
    [Column("GenreID")]
    public int GenreId { get; set; }

    [StringLength(50)]
    public string GenreName { get; set; } = null!;

    [InverseProperty("GenreNavigation")]
    public virtual ICollection<Beat> Beats { get; set; } = new List<Beat>();
}
