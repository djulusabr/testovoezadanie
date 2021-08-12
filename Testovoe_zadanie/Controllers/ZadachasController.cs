using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLib;
using MyLib.Data;

namespace Testovoe_zadanie.Controllers
{
    public class ZadachasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZadachasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zadachas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zadacha.ToListAsync());
        }

        // GET: Zadachas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zadacha = await _context.Zadacha
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zadacha == null)
            {
                return NotFound();
            }

            return View(zadacha);
        }

        // GET: Zadachas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zadachas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,DueDateTime,IsComplete")] Zadacha zadacha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zadacha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zadacha);
        }

        // GET: Zadachas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zadacha = await _context.Zadacha.FindAsync(id);
            if (zadacha == null)
            {
                return NotFound();
            }
            return View(zadacha);
        }

        // POST: Zadachas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,DueDateTime,IsComplete")] Zadacha zadacha)
        {
            if (id != zadacha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zadacha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZadachaExists(zadacha.Id))
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
            return View(zadacha);
        }

        // GET: Zadachas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zadacha = await _context.Zadacha
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zadacha == null)
            {
                return NotFound();
            }

            return View(zadacha);
        }

        // POST: Zadachas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zadacha = await _context.Zadacha.FindAsync(id);
            _context.Zadacha.Remove(zadacha);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Zadachas/Complete/5
        public async Task<IActionResult> Complete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zadacha = await _context.Zadacha
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zadacha == null)
            {
                return NotFound();
            }

            zadacha.IsComplete = !zadacha.IsComplete;
            _context.Update(zadacha);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZadachaExists(int id)
        {
            return _context.Zadacha.Any(e => e.Id == id);
        }
    }
}
