
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Areas.HotelManagement.Controllers {

    public class DashboardController : BaseController
    {
        private readonly HotelManagementContext _context;

        public DashboardController(HotelManagementContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View();
        }
    }

}
