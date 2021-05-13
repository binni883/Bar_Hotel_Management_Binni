using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bar_Hotel_Management_Binni.Data;
using Bar_Hotel_Management_Binni.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bar_Hotel_Management_Binni.Controllers
{
    [Authorize]
    public class FoodRateListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodRateListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FoodRateLists
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FoodRateLists.Include(f => f.FoodItems);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FoodRateLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodRateList = await _context.FoodRateLists
                .Include(f => f.FoodItems)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (foodRateList == null)
            {
                return NotFound();
            }

            return View(foodRateList);
        }

        // GET: FoodRateLists/Create
        public IActionResult Create()
        {
            ViewData["FoodItemID"] = new SelectList(_context.FoodItems, "ID", "ID");
            return View();
        }

        // POST: FoodRateLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FoodItemID,Rate,PlatType")] FoodRateList foodRateList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodRateList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FoodItemID"] = new SelectList(_context.FoodItems, "ID", "ID", foodRateList.FoodItemID);
            return View(foodRateList);
        }

        // GET: FoodRateLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodRateList = await _context.FoodRateLists.FindAsync(id);
            if (foodRateList == null)
            {
                return NotFound();
            }
            ViewData["FoodItemID"] = new SelectList(_context.FoodItems, "ID", "ID", foodRateList.FoodItemID);
            return View(foodRateList);
        }

        // POST: FoodRateLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FoodItemID,Rate,PlatType")] FoodRateList foodRateList)
        {
            if (id != foodRateList.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodRateList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodRateListExists(foodRateList.ID))
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
            ViewData["FoodItemID"] = new SelectList(_context.FoodItems, "ID", "ID", foodRateList.FoodItemID);
            return View(foodRateList);
        }

        // GET: FoodRateLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodRateList = await _context.FoodRateLists
                .Include(f => f.FoodItems)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (foodRateList == null)
            {
                return NotFound();
            }

            return View(foodRateList);
        }

        // POST: FoodRateLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodRateList = await _context.FoodRateLists.FindAsync(id);
            _context.FoodRateLists.Remove(foodRateList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodRateListExists(int id)
        {
            return _context.FoodRateLists.Any(e => e.ID == id);
        }
    }
}
