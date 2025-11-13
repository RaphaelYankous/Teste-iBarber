using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iBarber.Models;
using Microsoft.AspNetCore.Authorization;

namespace iBarber.Controllers
{
    [Authorize]
    public class ServiçosController : Controller
    {
        private readonly AppDbContext _context;

        public ServiçosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Serviços
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Serviços.Include(s => s.Barbearia);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Serviços/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviços = await _context.Serviços
                .Include(s => s.Barbearia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviços == null)
            {
                return NotFound();
            }

            return View(serviços);
        }

        // GET: Serviços/Create
        public IActionResult Create()
        {
            ViewData["BarbeariaId"] = new SelectList(_context.Barbearias, "Id", "Email");
            return View();
        }

        // POST: Serviços/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Preço,BarbeariaId")] Serviços serviços)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviços);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BarbeariaId"] = new SelectList(_context.Barbearias, "Id", "Email", serviços.BarbeariaId);
            return View(serviços);
        }

        // GET: Serviços/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviços = await _context.Serviços.FindAsync(id);
            if (serviços == null)
            {
                return NotFound();
            }
            ViewData["BarbeariaId"] = new SelectList(_context.Barbearias, "Id", "Email", serviços.BarbeariaId);
            return View(serviços);
        }

        // POST: Serviços/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Preço,BarbeariaId")] Serviços serviços)
        {
            if (id != serviços.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviços);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiçosExists(serviços.Id))
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
            ViewData["BarbeariaId"] = new SelectList(_context.Barbearias, "Id", "Email", serviços.BarbeariaId);
            return View(serviços);
        }

        // GET: Serviços/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviços = await _context.Serviços
                .Include(s => s.Barbearia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviços == null)
            {
                return NotFound();
            }

            return View(serviços);
        }

        // POST: Serviços/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviços = await _context.Serviços.FindAsync(id);
            if (serviços != null)
            {
                _context.Serviços.Remove(serviços);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiçosExists(int id)
        {
            return _context.Serviços.Any(e => e.Id == id);
        }
     

        }
    }

