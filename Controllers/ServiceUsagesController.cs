using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Models;

namespace HotelManagement.Controllers
{
    public class ServiceUsagesController : Controller
    {
        private readonly HotelManagementContext _context;

        public ServiceUsagesController(HotelManagementContext context)
        {
            _context = context;
        }

        // GET: ServiceUsages
        public async Task<IActionResult> Index()
        {
            var hotelManagementContext = _context.ServiceUsages.Include(s => s.Booking).Include(s => s.Service);
            return View(await hotelManagementContext.ToListAsync());
        }

        // GET: ServiceUsages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceUsage = await _context.ServiceUsages
                .Include(s => s.Booking)
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.UsageId == id);
            if (serviceUsage == null)
            {
                return NotFound();
            }

            return View(serviceUsage);
        }

        // GET: ServiceUsages/Create
        public IActionResult Create(int serviceId)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            
            // Check if the customer is logged in
            if (customerId == null)
            {
                TempData["Error"] = "Bạn cần đăng nhập để sử dụng chức năng này."; // Error message
                return RedirectToAction("Index", "LoginC"); // Redirect to login page
            }

            var customer = _context.Customers.Find(customerId);
            var service = _context.Services.Find(serviceId);

            if (customer == null || service == null)
            {
                return NotFound();
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId");
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId");
            return View();
        }

        // POST: ServiceUsages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsageId,BookingId,ServiceId,Quantity,TotalPrice")] ServiceUsage serviceUsage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceUsage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId", serviceUsage.BookingId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId", serviceUsage.ServiceId);
            return View(serviceUsage);
        }

        // GET: ServiceUsages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceUsage = await _context.ServiceUsages.FindAsync(id);
            if (serviceUsage == null)
            {
                return NotFound();
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId", serviceUsage.BookingId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId", serviceUsage.ServiceId);
            return View(serviceUsage);
        }

        // POST: ServiceUsages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsageId,BookingId,ServiceId,Quantity,TotalPrice")] ServiceUsage serviceUsage)
        {
            if (id != serviceUsage.UsageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceUsage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceUsageExists(serviceUsage.UsageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId", serviceUsage.BookingId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId", serviceUsage.ServiceId);
            return View(serviceUsage);
        }

        // GET: ServiceUsages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceUsage = await _context.ServiceUsages
                .Include(s => s.Booking)
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.UsageId == id);
            if (serviceUsage == null)
            {
                return NotFound();
            }

            return View(serviceUsage);
        }

        // POST: ServiceUsages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceUsage = await _context.ServiceUsages.FindAsync(id);
            if (serviceUsage != null)
            {
                _context.ServiceUsages.Remove(serviceUsage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceUsageExists(int id)
        {
            return _context.ServiceUsages.Any(e => e.UsageId == id);
        }
    }
}
