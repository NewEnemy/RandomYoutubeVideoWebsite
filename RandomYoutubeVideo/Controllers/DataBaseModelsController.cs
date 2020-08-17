using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RandomYoutubeVideo.Data;
using RandomYoutubeVideo.Models;

namespace RandomYoutubeVideo.Controllers
{
    public class DataBaseModelsController : Controller
    {
        private readonly DataBaseContext _context;

        public DataBaseModelsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: DataBaseModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataBaseModel.ToListAsync());
        }

        // GET: DataBaseModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataBaseModel = await _context.DataBaseModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataBaseModel == null)
            {
                return NotFound();
            }

            return View(dataBaseModel);
        }

        // GET: DataBaseModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataBaseModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VidId,Views,Rating")] DataBaseModel dataBaseModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataBaseModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataBaseModel);
        }

        // GET: DataBaseModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataBaseModel = await _context.DataBaseModel.FindAsync(id);
            if (dataBaseModel == null)
            {
                return NotFound();
            }
            return View(dataBaseModel);
        }

        // POST: DataBaseModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VidId,Views,Rating")] DataBaseModel dataBaseModel)
        {
            if (id != dataBaseModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataBaseModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataBaseModelExists(dataBaseModel.Id))
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
            return View(dataBaseModel);
        }

        // GET: DataBaseModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataBaseModel = await _context.DataBaseModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataBaseModel == null)
            {
                return NotFound();
            }

            return View(dataBaseModel);
        }

        // POST: DataBaseModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataBaseModel = await _context.DataBaseModel.FindAsync(id);
            _context.DataBaseModel.Remove(dataBaseModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataBaseModelExists(int id)
        {
            return _context.DataBaseModel.Any(e => e.Id == id);
        }
    }
}
