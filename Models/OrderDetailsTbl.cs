using System;
using System.Collections.Generic;

namespace OpticartWebAPI.Models;

public partial class OrderDetailsTbl
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Price { get; set; }

    public int Quantity { get; set; }

    public int Discount { get; set; }

    public int Total { get; set; }

    public int Size { get; set; }

    public int Color { get; set; }

    public virtual OrdersTbl Order { get; set; } = null!;

    public virtual ProductTbl Product { get; set; } = null!;
}
