using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public partial class Hotel
    {
        [Display(Name = "Mã Khách Sạn")]
        public int HotelId { get; set; }

        [Display(Name = "Tên Khách Sạn")]
        public string Name { get; set; } = null!;

        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; } = null!;

        [Display(Name = "Thành Phố")]
        public string City { get; set; } = null!;

        [Display(Name = "Số Điện Thoại")]
        public string Phone { get; set; } = null!;

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Đánh Giá")]
        public decimal? Rating { get; set; }

        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; } = null!;

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

        public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
    }
}
