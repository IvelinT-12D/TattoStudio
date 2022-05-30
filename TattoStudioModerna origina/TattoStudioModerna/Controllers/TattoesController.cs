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
        

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tatto.ToListAsync());
        }

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

        public IActionResult Create()
        {
            
            return View();
        }

      
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
