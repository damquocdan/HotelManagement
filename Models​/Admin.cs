using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public partial class Admin
    {
        [Display(Name = "Mã Quản Trị")]
        public int AdminId { get; set; }

        [Display(Name = "Tên Quản Trị")]
        public string Name { get; set; } = null!;

        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Display(Name = "Số Điện Thoại")]
        public string? Phone { get; set; }

        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; } = null!;

        [Display(Name = "Vai Trò")]
        public string? Role { get; set; }
    }
}
