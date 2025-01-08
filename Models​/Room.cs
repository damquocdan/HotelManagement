using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public partial class Room
    {
        [Display(Name = "Mã Phòng")]
        public int RoomId { get; set; }

        [Display(Name = "Mã Khách Sạn")]
        public int? HotelId { get; set; }

        [Display(Name = "Số Phòng")]
        public string RoomNumber { get; set; } = null!;

        [Display(Name = "Loại Phòng")]
        public string RoomType { get; set; } = null!;

        [Display(Name = "Giá Mỗi Đêm")]
        public decimal PricePerNight { get; set; }

        [Display(Name = "Trạng Thái")]
        public string? Status { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public virtual Hotel? Hotel { get; set; }
    }
}
