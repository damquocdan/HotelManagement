using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public partial class Payment
    {
        [Display(Name = "Mã Thanh Toán")]
        public int PaymentId { get; set; }

        [Display(Name = "Mã Đặt Phòng")]
        public int BookingId { get; set; }

        [Display(Name = "Ngày Thanh Toán")]
        public DateOnly PaymentDate { get; set; }

        [Display(Name = "Phương Thức Thanh Toán")]
        public string? PaymentMethod { get; set; }

        [Display(Name = "Số Tiền")]
        public decimal Amount { get; set; }

        public virtual Booking Booking { get; set; } = null!;
    }
}
