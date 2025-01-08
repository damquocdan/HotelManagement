using System;
using System.Collections.Generic;

namespace HotelManagement.Models​;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public decimal? Rating { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
