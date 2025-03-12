using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EcommerseBlazor.Models;

public partial class AdminLog
{
    [Key]
    [Column("LogID")]
    public int LogId { get; set; }

    [Column("AdminID")]
    public int AdminId { get; set; }

    [StringLength(255)]
    public string Action { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? Timestamp { get; set; }

    [ForeignKey("AdminId")]
    [InverseProperty("AdminLogs")]
    public virtual User Admin { get; set; } = null!;
}
