using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Sadas.Data;
using Proyecto_Sadas.Models;

namespace Proyecto_Sadas
{
    public class ArchivosController : Controller
    {
        private readonly ProyectoSadasContexto _context;

        public ArchivosController(ProyectoSadasContexto context)
        {
            _context = context;
        }

        // GET: Archivos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Archivo.ToListAsync());
        }

        // GET: Archivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Archivo == null)
            {
                return NotFound();
            }

            var archivo = await _context.Archivo
                .FirstOrDefaultAsync(m => m.archivo_id == id);
            if (archivo == null)
            {
                return NotFound();
            }

            return View(archivo);
        }

        // GET: Archivos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Archivos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("archivo_id,ruta,FileName,Length")] Archivo archivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(archivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(archivo);
        }

        // GET: Archivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Archivo == null)
            {
                return NotFound();
            }

            var archivo = await _context.Archivo.FindAsync(id);
            if (archivo == null)
            {
                return NotFound();
            }
            return View(archivo);
        }

        // POST: Archivos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("archivo_id,ruta,FileName,Length")] Archivo archivo)
        {
            if (id != archivo.archivo_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(archivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArchivoExists(archivo.archivo_id))
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
            return View(archivo);
        }

        // GET: Archivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Archivo == null)
            {
                return NotFound();
            }

            var archivo = await _context.Archivo
                .FirstOrDefaultAsync(m => m.archivo_id == id);
            if (archivo == null)
            {
                return NotFound();
            }

            return View(archivo);
        }

        // POST: Archivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Archivo == null)
            {
                return Problem("Entity set 'ProyectoSadasContexto.Archivo'  is null.");
            }
            var archivo = await _context.Archivo.FindAsync(id);
            if (archivo != null)
            {
                _context.Archivo.Remove(archivo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArchivoExists(int id)
        {
          return _context.Archivo.Any(e => e.archivo_id == id);
        }
    }
}
