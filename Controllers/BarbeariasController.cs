using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iBarber.Models;

namespace iBarber.Controllers
{
    public class BarbeariasController : Controller
    {
        private readonly AppDbContext _context;

        public BarbeariasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Barbearias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Barbearias.ToListAsync());
        }

        // GET: Barbearias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barbearias = await _context.Barbearias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barbearias == null)
            {
                return NotFound();
            }

            return View(barbearias);
        }

        // GET: Barbearias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Barbearias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Endereco,Telefone,Especialidade,Email")] Barbearias barbearias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barbearias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(barbearias);
        }

        // GET: Barbearias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barbearias = await _context.Barbearias.FindAsync(id);
            if (barbearias == null)
            {
                return NotFound();
            }
            return View(barbearias);
        }

        // POST: Barbearias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Endereco,Telefone,Especialidade,Email")] Barbearias barbearias)
        {
            if (id != barbearias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barbearias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarbeariasExists(barbearias.Id))
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
            return View(barbearias);
        }

        // GET: Barbearias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barbearias = await _context.Barbearias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barbearias == null)
            {
                return NotFound();
            }

            return View(barbearias);
        }

        // POST: Barbearias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barbearias = await _context.Barbearias.FindAsync(id);
            if (barbearias != null)
            {
                _context.Barbearias.Remove(barbearias);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarbeariasExists(int id)
        {
            return _context.Barbearias.Any(e => e.Id == id);
        }
    }
}
