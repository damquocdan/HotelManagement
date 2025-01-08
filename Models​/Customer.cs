using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public partial class Customer
    {
        [Display(Name = "Mã Khách Hàng")]
        public int CustomerId { get; set; }

        [Display(Name = "Tên Khách Hàng")]
        public string Name { get; set; } = null!;

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Số Điện Thoại")]
        public string? Phone { get; set; }

        [Display(Name = "Giới Tính")]
        public string? Gender { get; set; }

        [Display(Name = "Ngày Sinh")]
        public DateOnly? DateOfBirth { get; set; }

        [Display(Name = "Địa Chỉ")]
        public string? Address { get; set; }

        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
