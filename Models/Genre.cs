using System;
using System.Collections.Generic;

namespace EcommerseBlazor.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<Beat> Beats { get; set; } = new List<Beat>();
}
