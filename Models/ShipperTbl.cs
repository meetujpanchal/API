using System;
using System.Collections.Generic;

namespace OpticartWebAPI.Models;

public partial class ShipperTbl
{
    public int ShipperId { get; set; }

    public string CompanyName { get; set; } = null!;

    public int Contact { get; set; }
}
