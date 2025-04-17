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
    public class PartnerTypesController : Controller
    {
        private readonly MasterPolContext _context;

        public PartnerTypesController(MasterPolContext context)
        {
            _context = context;
        }

        // GET: PartnerTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PartnerTypes.ToListAsync());
        }

        // GET: PartnerTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnerType = await _context.PartnerTypes
                .FirstOrDefaultAsync(m => m.IdPartnerType == id);
            if (partnerType == null)
            {
                return NotFound();
            }

            return View(partnerType);
        }

        // GET: PartnerTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PartnerTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPartnerType,Name")] PartnerType partnerType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partnerType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partnerType);
        }

        // GET: PartnerTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnerType = await _context.PartnerTypes.FindAsync(id);
            if (partnerType == null)
            {
                return NotFound();
            }
            return View(partnerType);
        }

        // POST: PartnerTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPartnerType,Name")] PartnerType partnerType)
        {
            if (id != partnerType.IdPartnerType)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partnerType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnerTypeExists(partnerType.IdPartnerType))
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
            return View(partnerType);
        }

        // GET: PartnerTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnerType = await _context.PartnerTypes
                .FirstOrDefaultAsync(m => m.IdPartnerType == id);
            if (partnerType == null)
            {
                return NotFound();
            }

            return View(partnerType);
        }

        // POST: PartnerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partnerType = await _context.PartnerTypes.FindAsync(id);
            if (partnerType != null)
            {
                _context.PartnerTypes.Remove(partnerType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerTypeExists(int id)
        {
            return _context.PartnerTypes.Any(e => e.IdPartnerType == id);
        }
    }
}
