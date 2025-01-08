using System;
using System.Collections.Generic;

namespace HotelManagement.Models​;

public partial class Staff
{
    public int StaffId { get; set; }

    public int HotelId { get; set; }

    public string Name { get; set; } = null!;

    public string? Position { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public decimal? Salary { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
