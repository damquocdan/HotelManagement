using System;
using System.Collections.Generic;

namespace HotelManagement.Models​;

public partial class ServiceUsage
{
    public int UsageId { get; set; }

    public int? BookingId { get; set; }

    public int? ServiceId { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual Service? Service { get; set; }
}
