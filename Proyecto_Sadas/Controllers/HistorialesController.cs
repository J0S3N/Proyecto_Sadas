using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Sadas.Data;
using Proyecto_Sadas.Models;

namespace Proyecto_Sadas.Controllers
{
    public class HistorialesController : Controller
    {
        private readonly ProyectoSadasContexto _context;

        public HistorialesController(ProyectoSadasContexto context)
        {
            _context = context;
        }

        // GET: Historiales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Historial.ToListAsync());
        }

        // GET: Historiales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Historial == null)
            {
                return NotFound();
            }

            var historial = await _context.Historial
                .FirstOrDefaultAsync(m => m.id_historial == id);
            if (historial == null)
            {
                return NotFound();
            }

            return View(historial);
        }

        // GET: Historiales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Historiales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_historial,asesoria_previa,sede_asesoria_previa,adjunta_certificacion_medica_CCSS,adjunta_certificacion_medica_CONAPDIS,producto_apoyo_gubernamental,producto_apoyo_gubernamental_descripcion,producto_apoyo_no_gubernamental,producto_apoyo_no_gubernamental_descripcion")] Historial historial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historial);
        }

        // GET: Historiales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Historial == null)
            {
                return NotFound();
            }

            var historial = await _context.Historial.FindAsync(id);
            if (historial == null)
            {
                return NotFound();
            }
            return View(historial);
        }

        // POST: Historiales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_historial,asesoria_previa,sede_asesoria_previa,adjunta_certificacion_medica_CCSS,adjunta_certificacion_medica_CONAPDIS,producto_apoyo_gubernamental,producto_apoyo_gubernamental_descripcion,producto_apoyo_no_gubernamental,producto_apoyo_no_gubernamental_descripcion")] Historial historial)
        {
            if (id != historial.id_historial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialExists(historial.id_historial))
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
            return View(historial);
        }

        // GET: Historiales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Historial == null)
            {
                return NotFound();
            }

            var historial = await _context.Historial
                .FirstOrDefaultAsync(m => m.id_historial == id);
            if (historial == null)
            {
                return NotFound();
            }

            return View(historial);
        }

        // POST: Historiales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Historial == null)
            {
                return Problem("Entity set 'ProyectoSadasContexto.Historial'  is null.");
            }
            var historial = await _context.Historial.FindAsync(id);
            if (historial != null)
            {
                _context.Historial.Remove(historial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialExists(int id)
        {
            return _context.Historial.Any(e => e.id_historial == id);
        }
    }
}
