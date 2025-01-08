using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public partial class Booking
    {
        [Display(Name = "Mã Đặt Phòng")]
        public int BookingId { get; set; }

        [Display(Name = "Mã Khách Hàng")]
        public int? CustomerId { get; set; }

        [Display(Name = "Mã Phòng")]
        public int? RoomId { get; set; }

        [Display(Name = "Ngày Nhận Phòng")]
        public DateOnly CheckInDate { get; set; }

        [Display(Name = "Ngày Trả Phòng")]
        public DateOnly CheckOutDate { get; set; }

        [Display(Name = "Tổng Giá")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Trạng Thái")]
        public string? Status { get; set; }

        public virtual Customer? Customer { get; set; }

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

        public virtual Room? Room { get; set; }

        public virtual ICollection<ServiceUsage> ServiceUsages { get; set; } = new List<ServiceUsage>();
    }
}
