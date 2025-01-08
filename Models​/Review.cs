using System;
using System.Collections.Generic;

namespace HotelManagement.Models​;

public partial class Review
{
    public int ReviewId { get; set; }

    public int HotelId { get; set; }

    public int CustomerId { get; set; }

    public decimal? Rating { get; set; }

    public string? Comment { get; set; }

    public DateOnly ReviewDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Hotel Hotel { get; set; } = null!;
}
