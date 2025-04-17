using FrontendMVC.Data;
using FrontendMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FrontendMVC.Controllers
{
    public class PartnersController : Controller
    {
        private readonly MasterPolContext _context;

        public PartnersController(MasterPolContext context)
        {
            _context = context;
        }

        // GET: Partners
        public async Task<IActionResult> Index()
        {
            var masterPolContext = _context.Partners.Include(p => p.IdPartnerDirectorNavigation).Include(p => p.IdPartnerTypeNavigation).Include(p => p.OrderedProducts);
            return View(await masterPolContext.ToListAsync());
        }

        // GET: Partners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners
                .Include(p => p.IdPartnerDirectorNavigation)
                .Include(p => p.IdPartnerTypeNavigation)
                .Include(p => p.OrderedProducts)
                .FirstOrDefaultAsync(m => m.IdPartner == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // GET: Partners/Create
        public IActionResult Create()
        {
            ViewData["IdPartnerDirector"] = new SelectList(_context.PartnerDirectors, "IdPartnerDirector", "FullName");
            ViewData["IdPartnerType"] = new SelectList(_context.PartnerTypes, "IdPartnerType", "Name");
            return View();
        }

        // POST: Partners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPartner,IdPartnerType,IdPartnerDirector,Name,Inn,Address,Rating")] Partner partner)
        {
            _context.Add(partner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Partners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners.FindAsync(id);
            if (partner == null)
            {
                return NotFound();
            }
            ViewData["IdPartnerDirector"] = new SelectList(_context.PartnerDirectors, "IdPartnerDirector", "FullName", partner.IdPartnerDirector);
            ViewData["IdPartnerType"] = new SelectList(_context.PartnerTypes, "IdPartnerType", "Name", partner.IdPartnerType);
            return View(partner);
        }

        // POST: Partners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPartner,IdPartnerType,IdPartnerDirector,Name,Inn,Address,Rating")] Partner partner)
        {
            if (id != partner.IdPartner)
            {
                return NotFound();
            }

            try
            {
                _context.Update(partner);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerExists(partner.IdPartner))
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

        // GET: Partners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners
                .Include(p => p.IdPartnerDirectorNavigation)
                .Include(p => p.IdPartnerTypeNavigation)
                .FirstOrDefaultAsync(m => m.IdPartner == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // POST: Partners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partner = await _context.Partners.FindAsync(id);
            if (partner != null)
            {
                _context.Partners.Remove(partner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerExists(int id)
        {
            return _context.Partners.Any(e => e.IdPartner == id);
        }
    }
}
