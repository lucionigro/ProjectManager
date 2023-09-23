using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Context;
using ProjectManager.Models;

namespace ProjectManager.Controllers
{
    public class IssuesController : Controller
    {
        private readonly ProjectContext _context;

        public IssuesController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Issues
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.Issues.Include(i => i.Project).Include(i => i.Reporter);
            return View(await projectContext.ToListAsync());
        }

        // GET: Issues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Issues == null)
            {
                return NotFound();
            }

            var issue = await _context.Issues
                .Include(i => i.Project)
                .Include(i => i.Reporter)
                .FirstOrDefaultAsync(m => m.IssueId == id);
            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // GET: Issues/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
            ViewData["ReporterId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Issues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IssueId,Summary,Description,ProjectId,ReporterId,Created,Updated,Due")] Issue issue)
        {
            issue.Created = DateTime.Today;
            issue.Updated = DateTime.Today;

            if (ModelState.IsValid)
            {
                _context.Add(issue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", issue.ProjectId);
            ViewData["ReporterId"] = new SelectList(_context.Users, "UserId", "UserId", issue.ReporterId);
            return View(issue);
        }

        // GET: Issues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Issues == null)
            {
                return NotFound();
            }

            var issue = await _context.Issues.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", issue.ProjectId);
            ViewData["ReporterId"] = new SelectList(_context.Users, "UserId", "UserId", issue.ReporterId);
            return View(issue);
        }

        // POST: Issues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IssueId,Summary,Description,ProjectId,ReporterId,Created,Updated,Due")] Issue issue)
        {
            if (id != issue.IssueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssueExists(issue.IssueId))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", issue.ProjectId);
            ViewData["ReporterId"] = new SelectList(_context.Users, "UserId", "UserId", issue.ReporterId);
            return View(issue);
        }

        // GET: Issues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Issues == null)
            {
                return NotFound();
            }

            var issue = await _context.Issues
                .Include(i => i.Project)
                .Include(i => i.Reporter)
                .FirstOrDefaultAsync(m => m.IssueId == id);
            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // POST: Issues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Issues == null)
            {
                return Problem("Entity set 'ProjectContext.Issues'  is null.");
            }
            var issue = await _context.Issues.FindAsync(id);
            if (issue != null)
            {
                _context.Issues.Remove(issue);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssueExists(int id)
        {
          return (_context.Issues?.Any(e => e.IssueId == id)).GetValueOrDefault();
        }
    }
}
