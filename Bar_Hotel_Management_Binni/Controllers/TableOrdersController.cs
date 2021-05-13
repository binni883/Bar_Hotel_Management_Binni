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
    public class TableOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TableOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TableOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.TableOrders.ToListAsync());
        }

        // GET: TableOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableOrder = await _context.TableOrders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tableOrder == null)
            {
                return NotFound();
            }

            return View(tableOrder);
        }

        // GET: TableOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TableOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,OrderNo,KOT,OrderDate")] TableOrder tableOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tableOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tableOrder);
        }

        // GET: TableOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableOrder = await _context.TableOrders.FindAsync(id);
            if (tableOrder == null)
            {
                return NotFound();
            }
            return View(tableOrder);
        }

        // POST: TableOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,OrderNo,KOT,OrderDate")] TableOrder tableOrder)
        {
            if (id != tableOrder.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableOrderExists(tableOrder.ID))
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
            return View(tableOrder);
        }

        // GET: TableOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableOrder = await _context.TableOrders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tableOrder == null)
            {
                return NotFound();
            }

            return View(tableOrder);
        }

        // POST: TableOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tableOrder = await _context.TableOrders.FindAsync(id);
            _context.TableOrders.Remove(tableOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableOrderExists(int id)
        {
            return _context.TableOrders.Any(e => e.ID == id);
        }
    }
}
