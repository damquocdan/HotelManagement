using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public partial class Staff
    {
        public int StaffId { get; set; }

        public int HotelId { get; set; }

        [Display(Name = "Tên Nhân Viên")]
        public string Name { get; set; } = null!;

        [Display(Name = "Chức Vụ")]
        public string? Position { get; set; }

        [Display(Name = "Số Điện Thoại")]
        public string? Phone { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Mức Lương")]
        public decimal? Salary { get; set; }

        [Display(Name = "Khách Sạn")]
        public virtual Hotel Hotel { get; set; } = null!;
    }
}
