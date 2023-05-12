using System;
using System.Collections.Generic;

namespace OpticartWebAPI.Models;

public partial class CustomerTbl
{
    public int CustomerId { get; set; }

    public string CustomerFname { get; set; } = null!;

    public string CustomerLname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Pincode { get; set; }

    public virtual ICollection<FeedbackTbl> FeedbackTbls { get; set; } = new List<FeedbackTbl>();

    public virtual ICollection<OrdersTbl> OrdersTbls { get; set; } = new List<OrdersTbl>();
}
