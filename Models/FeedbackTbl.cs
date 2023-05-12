using System;
using System.Collections.Generic;

namespace OpticartWebAPI.Models;

public partial class FeedbackTbl
{
    public int FdId { get; set; }

    public string FeedbackTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Ratings { get; set; }

    public DateOnly FeedbackDate { get; set; }

    public int CustomerId { get; set; }

    public int CatgoryId { get; set; }

    public int ProductId { get; set; }

    public virtual CategoryTbl Catgory { get; set; } = null!;

    public virtual CustomerTbl Customer { get; set; } = null!;

    public virtual ProductTbl Product { get; set; } = null!;
}
