using System;
using System.Collections.Generic;

namespace api_db_first.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
