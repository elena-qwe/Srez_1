using System;
using System.Collections.Generic;

namespace Srez_1.Models;

public partial class TableRole
{
    public int Id { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<TableUser> TableUsers { get; } = new List<TableUser>();
}
