using System;
using System.Collections.Generic;

namespace HotelManagement.Models​;

public partial class Room
{
    public int RoomId { get; set; }

    public int? HotelId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public string RoomType { get; set; } = null!;

    public decimal PricePerNight { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Hotel? Hotel { get; set; }
}
