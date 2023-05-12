using System;
using System.Collections.Generic;

namespace OpticartWebAPI.Models;

public partial class OrdersTbl
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int CustomerId { get; set; }

    public int Paymentid { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly Shipdate { get; set; }

    public DateOnly PaymentDate { get; set; }

    public virtual CustomerTbl Customer { get; set; } = null!;

    public virtual ICollection<OrderDetailsTbl> OrderDetailsTbls { get; set; } = new List<OrderDetailsTbl>();

    public virtual PaymentTbl Payment { get; set; } = null!;

    public virtual ProductTbl Product { get; set; } = null!;
}
