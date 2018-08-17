using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspCore1.Models;

namespace AspCore1.Controllers
{
    public class DownloadsController : Controller
    {
        private readonly DownloadContext _context;

        public DownloadsController(DownloadContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchterm)
        {
            ViewData["lastSearch"] = searchterm;
            if (!String.IsNullOrEmpty(searchterm))
            {
                var downloads = _context.Download.Where(s => s.File.IndexOf(searchterm, StringComparison.OrdinalIgnoreCase) >= 0 || s.ProductName.IndexOf(searchterm,StringComparison.OrdinalIgnoreCase) >= 0);
                return View(await downloads.ToListAsync());
            }
            //Return everything because they must have searched empty
            return View(await _context.Download.ToListAsync());
        }

        // GET: Downloads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var download = await _context.Download
                .FirstOrDefaultAsync(m => m.Id == id);
            if (download == null)
            {
                return NotFound();
            }

            return View(download);
        }

        // GET: Downloads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Downloads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,File,Modified,SizeKb,ProductName")] Download download)
        {
            if (ModelState.IsValid)
            {
                _context.Add(download);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(download);
        }

        // GET: Downloads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var download = await _context.Download.FindAsync(id);
            if (download == null)
            {
                return NotFound();
            }
            return View(download);
        }

        // POST: Downloads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,File,Modified,SizeKb,ProductName")] Download download)
        {
            if (id != download.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(download);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DownloadExists(download.Id))
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
            return View(download);
        }

        // GET: Downloads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var download = await _context.Download
                .FirstOrDefaultAsync(m => m.Id == id);
            if (download == null)
            {
                return NotFound();
            }

            return View(download);
        }

        // POST: Downloads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var download = await _context.Download.FindAsync(id);
            _context.Download.Remove(download);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DownloadExists(int id)
        {
            return _context.Download.Any(e => e.Id == id);
        }
    }
}
