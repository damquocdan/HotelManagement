using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.AdminHotels.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly HotelManagementContext _context;

        public DashboardController(HotelManagementContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var totalHotels = await _context.Hotels.CountAsync();
            var totalStaff = await _context.Staff.CountAsync();
            var totalRooms = await _context.Rooms.CountAsync();
            var totalCustomers = await _context.Customers.CountAsync();
            var totalBookings = await _context.Bookings.CountAsync();
            var totalServices = await _context.Services.CountAsync();
            var totalReviews = await _context.Reviews.CountAsync();

            // Get the average rating for each hotel
            var hotelRatings = await _context.Hotels
                .Select(h => new
                {
                    HotelId = h.HotelId,
                    HotelName = h.Name,
                    AverageRating = h.Reviews.Average(r => r.Rating) // Get the average rating
                })
                .ToListAsync();

            // Prepare data for the view
            ViewBag.TotalHotels = totalHotels;
            ViewBag.TotalStaff = totalStaff;
            ViewBag.TotalRooms = totalRooms;
            ViewBag.TotalCustomers = totalCustomers;
            ViewBag.TotalBookings = totalBookings;
            ViewBag.TotalServices = totalServices;
            ViewBag.TotalReviews = totalReviews;
            ViewBag.HotelRatings = hotelRatings;  // Pass hotel ratings to the view

            return View();
        }
    }
}
