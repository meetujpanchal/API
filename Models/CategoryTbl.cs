using System;
using System.Collections.Generic;

namespace OpticartWebAPI.Models;

public partial class CategoryTbl
{
    public int CategoryId { get; set; }

    public string Categoryname { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Image { get; set; } = null!;

    public string ActiveStatus { get; set; } = null!;

    public virtual ICollection<FeedbackTbl> FeedbackTbls { get; set; } = new List<FeedbackTbl>();

    public virtual ICollection<ProductTbl> ProductTbls { get; set; } = new List<ProductTbl>();
}
