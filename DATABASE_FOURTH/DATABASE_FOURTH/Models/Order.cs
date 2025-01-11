using System;
using System.Collections.Generic;

namespace DATABASE_FOURTH.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime Timeorder { get; set; }

    public string Status { get; set; } = null!;

    public int? IdUsers { get; set; }

    public virtual User? IdUsersNavigation { get; set; }

    public virtual ICollection<Item> IdItems { get; set; } = new List<Item>();
}
