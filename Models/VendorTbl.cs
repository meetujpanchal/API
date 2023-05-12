using System;
using System.Collections.Generic;

namespace OpticartWebAPI.Models;

public partial class VendorTbl
{
    public int VendorId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public int Contact { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public int Pin { get; set; }

    public string GoodsType { get; set; } = null!;

    public virtual ICollection<ProductTbl> ProductTbls { get; set; } = new List<ProductTbl>();
}
