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
    public class job_Meta_InfoController : Controller
    {
        private readonly nycgovworkContext _context;

        public job_Meta_InfoController(nycgovworkContext context)
        {
            _context = context;
        }

        // GET: job_Meta_Info
        public async Task<IActionResult> Index()
        {
            return View(await _context.job_info_short.ToListAsync());
        }

        // GET: job_Meta_Info/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_info_short = await _context.job_info_short
                .FirstOrDefaultAsync(m => m.jobNum == id);
            if (job_info_short == null)
            {
                return NotFound();
            }

            return View(job_info_short);
        }

        // GET: job_Meta_Info/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: job_Meta_Info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("hiring_agency,jobLink,jobNum,job_ID,business_title,civil_title,title_class,job_category,career_level,work_location,division_work_unit,total_openings,title_code,level,proposed_salary_range,posted,post_until")] job_info_short job_info_short)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job_info_short);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(job_info_short);
        }

        // GET: job_Meta_Info/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_info_short = await _context.job_info_short.FindAsync(id);
            if (job_info_short == null)
            {
                return NotFound();
            }
            return View(job_info_short);
        }

        // POST: job_Meta_Info/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("hiring_agency,jobLink,jobNum,job_ID,business_title,civil_title,title_class,job_category,career_level,work_location,division_work_unit,total_openings,title_code,level,proposed_salary_range,posted,post_until")] job_info_short job_info_short)
        {
            if (id != job_info_short.jobNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job_info_short);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!job_info_shortExists(job_info_short.jobNum))
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
            return View(job_info_short);
        }

        // GET: job_Meta_Info/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_info_short = await _context.job_info_short
                .FirstOrDefaultAsync(m => m.jobNum == id);
            if (job_info_short == null)
            {
                return NotFound();
            }

            return View(job_info_short);
        }

        // POST: job_Meta_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job_info_short = await _context.job_info_short.FindAsync(id);
            _context.job_info_short.Remove(job_info_short);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool job_info_shortExists(int id)
        {
            return _context.job_info_short.Any(e => e.jobNum == id);
        }
    }
}
