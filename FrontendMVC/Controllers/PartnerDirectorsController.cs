using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrontendMVC.Data;
using FrontendMVC.Models;

namespace FrontendMVC.Controllers
{
    public class PartnerDirectorsController : Controller
    {
        private readonly MasterPolContext _context;

        public PartnerDirectorsController(MasterPolContext context)
        {
            _context = context;
        }

        // GET: PartnerDirectors
        public async Task<IActionResult> Index()
        {
            return View(await _context.PartnerDirectors.ToListAsync());
        }

        // GET: PartnerDirectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnerDirector = await _context.PartnerDirectors
                .FirstOrDefaultAsync(m => m.IdPartnerDirector == id);
            if (partnerDirector == null)
            {
                return NotFound();
            }

            return View(partnerDirector);
        }

        // GET: PartnerDirectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PartnerDirectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPartnerDirector,Surname,FirstName,Patronymic,PhoneNumber,Email")] PartnerDirector partnerDirector)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partnerDirector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partnerDirector);
        }

        // GET: PartnerDirectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnerDirector = await _context.PartnerDirectors.FindAsync(id);
            if (partnerDirector == null)
            {
                return NotFound();
            }
            return View(partnerDirector);
        }

        // POST: PartnerDirectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPartnerDirector,Surname,FirstName,Patronymic,PhoneNumber,Email")] PartnerDirector partnerDirector)
        {
            if (id != partnerDirector.IdPartnerDirector)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partnerDirector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnerDirectorExists(partnerDirector.IdPartnerDirector))
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
            return View(partnerDirector);
        }

        // GET: PartnerDirectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnerDirector = await _context.PartnerDirectors
                .FirstOrDefaultAsync(m => m.IdPartnerDirector == id);
            if (partnerDirector == null)
            {
                return NotFound();
            }

            return View(partnerDirector);
        }

        // POST: PartnerDirectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partnerDirector = await _context.PartnerDirectors.FindAsync(id);
            if (partnerDirector != null)
            {
                _context.PartnerDirectors.Remove(partnerDirector);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerDirectorExists(int id)
        {
            return _context.PartnerDirectors.Any(e => e.IdPartnerDirector == id);
        }
    }
}
