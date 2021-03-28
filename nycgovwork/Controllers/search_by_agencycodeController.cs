using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nycgovwork.Data;
using nycgovwork.Models;

namespace nycgovwork.Controllers
{
    public class search_by_agencycodeController : Controller
    {
        private readonly nycgovworkContext _context;

        public search_by_agencycodeController(nycgovworkContext context)
        {
            _context = context;
        }

        // GET: search_by_agencycode
        public async Task<IActionResult> Index()
        {
            return View(await _context.search_by_agencycode.ToListAsync());
        }

        // GET: search_by_agencycode/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var search_by_agencycode = await _context.search_by_agencycode
                .FirstOrDefaultAsync(m => m.jobNum == id);
            if (search_by_agencycode == null)
            {
                return NotFound();
            }

            return View(search_by_agencycode);
        }

        // GET: search_by_agencycode/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: search_by_agencycode/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("jobNum,Title,Link,shortCategory,LongCategory,Department,Location,Agency,Posted_Date")] search_by_agencycode search_by_agencycode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(search_by_agencycode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(search_by_agencycode);
        }

        // GET: search_by_agencycode/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var search_by_agencycode = await _context.search_by_agencycode.FindAsync(id);
            if (search_by_agencycode == null)
            {
                return NotFound();
            }
            return View(search_by_agencycode);
        }

        // POST: search_by_agencycode/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("jobNum,Title,Link,shortCategory,LongCategory,Department,Location,Agency,Posted_Date")] search_by_agencycode search_by_agencycode)
        {
            if (id != search_by_agencycode.jobNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(search_by_agencycode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!search_by_agencycodeExists(search_by_agencycode.jobNum))
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
            return View(search_by_agencycode);
        }

        // GET: search_by_agencycode/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var search_by_agencycode = await _context.search_by_agencycode
                .FirstOrDefaultAsync(m => m.jobNum == id);
            if (search_by_agencycode == null)
            {
                return NotFound();
            }

            return View(search_by_agencycode);
        }

        // POST: search_by_agencycode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var search_by_agencycode = await _context.search_by_agencycode.FindAsync(id);
            _context.search_by_agencycode.Remove(search_by_agencycode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool search_by_agencycodeExists(int id)
        {
            return _context.search_by_agencycode.Any(e => e.jobNum == id);
        }
    }
}
