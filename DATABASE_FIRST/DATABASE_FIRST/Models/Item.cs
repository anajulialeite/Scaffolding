using System;
using System.Collections.Generic;

namespace DATABASE_FIRST.Models;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal? Price { get; set; }

    public string Imagem { get; set; } = null!;

    public int? IdCategory { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual ICollection<Order> IdOrders { get; set; } = new List<Order>();
}
