using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public partial class Service
    {
        [Display(Name = "Mã Dịch Vụ")]
        public int ServiceId { get; set; }

        [Display(Name = "Tên Dịch Vụ")]
        public string Name { get; set; } = null!;

        [Display(Name = "Mô Tả")]
        public string? Description { get; set; }

        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        public virtual ICollection<ServiceUsage> ServiceUsages { get; set; } = new List<ServiceUsage>();
    }
}
