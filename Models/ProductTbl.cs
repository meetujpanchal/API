using System;
using System.Collections.Generic;

namespace OpticartWebAPI.Models;

public partial class ProductTbl
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int VendorId { get; set; }

    public int CategoryId { get; set; }

    public string Quantity { get; set; } = null!;

    public int ProductPrice { get; set; }

    public int Size { get; set; }

    public string Color { get; set; } = null!;

    public int InStockProductNumber { get; set; }

    public string ProductImage { get; set; } = null!;

    public virtual CategoryTbl Category { get; set; } = null!;

    public virtual ICollection<FeedbackTbl> FeedbackTbls { get; set; } = new List<FeedbackTbl>();

    public virtual ICollection<OrderDetailsTbl> OrderDetailsTbls { get; set; } = new List<OrderDetailsTbl>();

    public virtual ICollection<OrdersTbl> OrdersTbls { get; set; } = new List<OrdersTbl>();

    public virtual VendorTbl Vendor { get; set; } = null!;
}
