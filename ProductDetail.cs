using System;
using System.Collections.Generic;

namespace TestSample.Model.Data;

public partial class ProductDetail
{
    public int ProductDetailId { get; set; }

    public string? ProductName { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public string? Url { get; set; }
}
