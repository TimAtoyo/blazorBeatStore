using System;
using System.Collections.Generic;

namespace EcommerseBlazor;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<AdminLog> AdminLogs { get; set; } = new List<AdminLog>();

    public virtual ICollection<Beat> Beats { get; set; } = new List<Beat>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
