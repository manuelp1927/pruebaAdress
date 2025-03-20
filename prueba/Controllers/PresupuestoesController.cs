﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prueba.Models;

namespace prueba.Controllers
{
    public class PresupuestoesController : Controller
    {
        private readonly PruebaContext _context;

        public PresupuestoesController(PruebaContext context)
        {
            _context = context;
        }

        // GET: Presupuestoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Presupuestos.ToListAsync());
        }

        // GET: Presupuestoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuesto = await _context.Presupuestos
                .FirstOrDefaultAsync(m => m.PresupuestoId == id);
            if (presupuesto == null)
            {
                return NotFound();
            }

            return View(presupuesto);
        }

        // GET: Presupuestoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Presupuestoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PresupuestoId,Unidad,TipoBienServicio,Cantidad,ValorUnitario,ValorTotal,FechaAdquision,Proveedor,Documentacion")] Presupuesto presupuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presupuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(presupuesto);
        }

        // GET: Presupuestoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuesto = await _context.Presupuestos.FindAsync(id);
            if (presupuesto == null)
            {
                return NotFound();
            }
            return View(presupuesto);
        }

        // POST: Presupuestoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PresupuestoId,Unidad,TipoBienServicio,Cantidad,ValorUnitario,ValorTotal,FechaAdquision,Proveedor,Documentacion")] Presupuesto presupuesto)
        {
            if (id != presupuesto.PresupuestoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presupuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresupuestoExists(presupuesto.PresupuestoId))
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
            return View(presupuesto);
        }

        // GET: Presupuestoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuesto = await _context.Presupuestos
                .FirstOrDefaultAsync(m => m.PresupuestoId == id);
            if (presupuesto == null)
            {
                return NotFound();
            }

            return View(presupuesto);
        }

        // POST: Presupuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presupuesto = await _context.Presupuestos.FindAsync(id);
            if (presupuesto != null)
            {
                _context.Presupuestos.Remove(presupuesto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresupuestoExists(int id)
        {
            return _context.Presupuestos.Any(e => e.PresupuestoId == id);
        }
    }
}
