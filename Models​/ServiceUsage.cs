using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public partial class ServiceUsage
    {
        [Display(Name = "Mã Sử Dụng")]
        public int UsageId { get; set; }

        [Display(Name = "Mã Đặt Phòng")]
        public int? BookingId { get; set; }

        [Display(Name = "Mã Dịch Vụ")]
        public int? ServiceId { get; set; }

        [Display(Name = "Số Lượng")]
        public int Quantity { get; set; }

        [Display(Name = "Tổng Giá")]
        public decimal TotalPrice { get; set; }

        public virtual Booking? Booking { get; set; }

        public virtual Service? Service { get; set; }
    }
}
