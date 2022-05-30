using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TattoStudioModerna.Data;
using TattoStudioModerna.Models;

namespace TattoStudioModerna.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public OrdersController(ApplicationDbContext context,
                                UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Orders
        //public async Task<IActionResult> Index()
        //{

        //    var applicationDbContext = _context.Order.Include(o => o.Tatto);
        //    return View(await applicationDbContext.ToListAsync());
        //}
        
        public async Task<IActionResult> Index()//GetMyOrders()
        {
            if (User.IsInRole("Admin"))
            {
                var applicationDbContext = _context.Order
                .Include(o => o.Tatto)
                .Include(o => o.User);
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                var currentUser = _userManager.GetUserId(User);
                var myOrders = _context.Order
                               .Include(o => o.Tatto)
                               .Include(u => u.User)
                               .Where(x => x.UserId == currentUser.ToString())
                               .ToListAsync();

                return View(await myOrders);
            }
        }

            // GET: Orders/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(x => x.User)
                .Include(o => o.Tatto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["TattoId"] = new SelectList(_context.Tatto, "Id", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,TattoId,OrderOn")] OrderVM order)
        {
            if (!ModelState.IsValid)
            {
                ViewData["TattoId"] = new SelectList(_context.Tatto, "Id", "Name", order.TattoId);
                return View(order);
            }
            Order model = new()
            {
                TattoId = order.TattoId,
                UserId = _userManager.GetUserId(User),
                OrderOn = DateTime.Now
            };
            _context.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["TattoId"] = new SelectList(_context.Tatto, "Id", "Name", order.TattoId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,TattoId,OrderOn")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                order.UserId = _userManager.GetUserId(User);
                order.OrderOn = DateTime.Now;
                _context.Update(order);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(order.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            ViewData["TattoId"] = new SelectList(_context.Tatto, "Id", "Name", order.TattoId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(x => x.User)
                .Include(o => o.Tatto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
