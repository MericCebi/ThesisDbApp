using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThesisDbApp.Data;
using ThesisDbApp.Models;

namespace ThesisDbApp.Controllers
{
    public class ThesesController : Controller
    {
        private readonly AppDbContext _context;

        public ThesesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Theses
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Thesis.Include(t => t.ChairName);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Theses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Thesis == null)
            {
                return NotFound();
            }

            var thesis = await _context.Thesis
                .Include(t => t.ChairName)
                .FirstOrDefaultAsync(m => m.id == id);
            if (thesis == null)
            {
                return NotFound();
            }

            return View(thesis);
        }

        // GET: Theses/Create
        public IActionResult Create()
        {
            ViewData["ChairId"] = new SelectList(_context.Chair, "Id", "Id");
            return View();
        }

        // POST: Theses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Title,Description,Bachelor,Master,StudentName,StudentEmail,StudentID,Registration,Filing,Summary,Strengths,Weakness,Evaluation,ContentVal,LayoutVal,StructureVal,StyleVal,LiteratureVal,DifficultyVal,NoveltyVal,RichnessVal,ContentWt,LayoutWt,StructureWt,StyleWt,LiteratureWt,DifficultyWt,NoveltyWt,RichnessWt,Grade,LastModified,ChairId")] Thesis thesis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thesis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChairId"] = new SelectList(_context.Chair, "Id", "Id", thesis.ChairId);
            return View(thesis);
        }

        // GET: Theses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Thesis == null)
            {
                return NotFound();
            }

            var thesis = await _context.Thesis.FindAsync(id);
            if (thesis == null)
            {
                return NotFound();
            }
            ViewData["ChairId"] = new SelectList(_context.Chair, "Id", "Id", thesis.ChairId);
            return View(thesis);
        }

        // POST: Theses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Title,Description,Bachelor,Master,StudentName,StudentEmail,StudentID,Registration,Filing,Summary,Strengths,Weakness,Evaluation,ContentVal,LayoutVal,StructureVal,StyleVal,LiteratureVal,DifficultyVal,NoveltyVal,RichnessVal,ContentWt,LayoutWt,StructureWt,StyleWt,LiteratureWt,DifficultyWt,NoveltyWt,RichnessWt,Grade,LastModified,ChairId")] Thesis thesis)
        {
            if (id != thesis.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thesis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThesisExists(thesis.id))
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
            ViewData["ChairId"] = new SelectList(_context.Chair, "Id", "Id", thesis.ChairId);
            return View(thesis);
        }

        // GET: Theses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Thesis == null)
            {
                return NotFound();
            }

            var thesis = await _context.Thesis
                .Include(t => t.ChairName)
                .FirstOrDefaultAsync(m => m.id == id);
            if (thesis == null)
            {
                return NotFound();
            }

            return View(thesis);
        }

        // POST: Theses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Thesis == null)
            {
                return Problem("Entity set 'AppDbContext.Thesis'  is null.");
            }
            var thesis = await _context.Thesis.FindAsync(id);
            if (thesis != null)
            {
                _context.Thesis.Remove(thesis);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThesisExists(int id)
        {
          return _context.Thesis.Any(e => e.id == id);
        }
    }
}
