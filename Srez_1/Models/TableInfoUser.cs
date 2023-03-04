using System;
using System.Collections.Generic;

namespace Srez_1.Models;

public partial class TableInfoUser
{
    public int Id { get; set; }

    public decimal? PhoneNumber { get; set; }

    public DateOnly? BirthdayDate { get; set; }

    public string? AddressHome { get; set; }

    public virtual ICollection<TableUser> TableUsers { get; } = new List<TableUser>();
}
