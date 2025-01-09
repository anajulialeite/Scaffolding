using System;
using System.Collections.Generic;

namespace DATABASE_FIRST.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Namme { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
