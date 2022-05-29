using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TattoStudioModerna.Data;


namespace TattoStudioModerna.Controllers
{
    public class TattoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TattoesController(ApplicationDbContext context)
        {
            _context = context;
        }
        

        // GET: Tattoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tatto.ToListAsync());
        }

        // GET: Tattoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatto = await _context.Tatto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tatto == null)
            {
                return NotFound();
            }

            return View(tatto);
        }

        // GET: Tattoes/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Tattoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Image,Discription,Price,Date")] Tatto tatto)
        {
            if (ModelState.IsValid)
            {
                tatto.Date = DateTime.Now;
                _context.Add(tatto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tatto);
        }

        // GET: Tattoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatto = await _context.Tatto.FindAsync(id);
            if (tatto == null)
            {
                return NotFound();
            }
            return View(tatto);
        }

        // POST: Tattoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,Discription,Price,Date")] Tatto tatto)
        {
            if (id != tatto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                try
                {
                    _context.Update(tatto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TattoExists(tatto.Id))
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
            return View(tatto);
        }

        // GET: Tattoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatto = await _context.Tatto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tatto == null)
            {
                return NotFound();
            }

            return View(tatto);
        }

        // POST: Tattoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tatto = await _context.Tatto.FindAsync(id);
            _context.Tatto.Remove(tatto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TattoExists(int id)
        {
            return _context.Tatto.Any(e => e.Id == id);
        }
    }
}
