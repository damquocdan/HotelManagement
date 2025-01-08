using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public partial class Review
    {
        [Display(Name = "Mã Đánh Giá")]
        public int ReviewId { get; set; }

        [Display(Name = "Mã Khách Sạn")]
        public int HotelId { get; set; }

        [Display(Name = "Mã Khách Hàng")]
        public int CustomerId { get; set; }

        [Display(Name = "Đánh Giá")]
        public decimal? Rating { get; set; }

        [Display(Name = "Bình Luận")]
        public string? Comment { get; set; }

        [Display(Name = "Ngày Đánh Giá")]
        public DateOnly ReviewDate { get; set; }

        public virtual Customer Customer { get; set; } = null!;

        public virtual Hotel Hotel { get; set; } = null!;
    }
}
