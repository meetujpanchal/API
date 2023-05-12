using System;
using System.Collections.Generic;

namespace OpticartWebAPI.Models;

public partial class PaymentTbl
{
    public int PaymentId { get; set; }

    public string PaymentType { get; set; } = null!;

    public string Allowed { get; set; } = null!;

    public virtual ICollection<OrdersTbl> OrdersTbls { get; set; } = new List<OrdersTbl>();
}
