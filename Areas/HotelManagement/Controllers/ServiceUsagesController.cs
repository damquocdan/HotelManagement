using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Models;

namespace HotelManagement.Areas.HotelManagement.Controllers
{
    [Area("HotelManagement")]
    public class ServiceUsagesController : Controller
    {
        private readonly HotelManagementContext _context;

        public ServiceUsagesController(HotelManagementContext context)
        {
            _context = context;
        }

        // GET: HotelManagement/ServiceUsages
        public async Task<IActionResult> Index()
        {
            var hotelManagementContext = _context.ServiceUsages.Include(s => s.Booking).Include(s => s.Service);
            return View(await hotelManagementContext.ToListAsync());
        }

        // GET: HotelManagement/ServiceUsages/Details/5
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

        // GET: HotelManagement/ServiceUsages/Create
        public IActionResult Create()
        {
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId");
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId");
            return View();
        }

        // POST: HotelManagement/ServiceUsages/Create
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

        // GET: HotelManagement/ServiceUsages/Edit/5
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

        // POST: HotelManagement/ServiceUsages/Edit/5
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

        // GET: HotelManagement/ServiceUsages/Delete/5
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

        // POST: HotelManagement/ServiceUsages/Delete/5
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
