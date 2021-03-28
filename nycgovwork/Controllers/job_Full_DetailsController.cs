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
    public class job_Full_DetailsController : Controller
    {
        private readonly nycgovworkContext _context;

        public job_Full_DetailsController(nycgovworkContext context)
        {
            _context = context;
        }

        // GET: job_Full_Details
        public async Task<IActionResult> Index()
        {
            return View(await _context.job_info_details.ToListAsync());
        }

        // GET: job_Full_Details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_info_details = await _context.job_info_details
                .FirstOrDefaultAsync(m => m.jobNum == id);
            if (job_info_details == null)
            {
                return NotFound();
            }

            return View(job_info_details);
        }

        // GET: job_Full_Details/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: job_Full_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("add_info,hours_shift,job_descrip,min_qual,preferred_skills,recruit_contact,residency_req,to_apply,work_location,jobNum")] job_info_details job_info_details)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job_info_details);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(job_info_details);
        }

        // GET: job_Full_Details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_info_details = await _context.job_info_details.FindAsync(id);
            if (job_info_details == null)
            {
                return NotFound();
            }
            return View(job_info_details);
        }

        // POST: job_Full_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("add_info,hours_shift,job_descrip,min_qual,preferred_skills,recruit_contact,residency_req,to_apply,work_location,jobNum")] job_info_details job_info_details)
        {
            if (id != job_info_details.jobNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job_info_details);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!job_info_detailsExists(job_info_details.jobNum))
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
            return View(job_info_details);
        }

        // GET: job_Full_Details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_info_details = await _context.job_info_details
                .FirstOrDefaultAsync(m => m.jobNum == id);
            if (job_info_details == null)
            {
                return NotFound();
            }

            return View(job_info_details);
        }

        // POST: job_Full_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job_info_details = await _context.job_info_details.FindAsync(id);
            _context.job_info_details.Remove(job_info_details);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool job_info_detailsExists(int id)
        {
            return _context.job_info_details.Any(e => e.jobNum == id);
        }
    }
}
