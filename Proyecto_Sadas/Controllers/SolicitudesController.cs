using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Sadas.Data;
using Proyecto_Sadas.Models;

namespace Proyecto_Sadas.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly ProyectoSadasContexto _context;

        public SolicitudesController(ProyectoSadasContexto context)
        {
            _context = context;
        }

        // GET: Solicitudes
        public async Task<IActionResult> Indice()
        {
            return View(await _context.Solicitud.ToListAsync());
        }

        // GET: Solicitudes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Solicitud == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud
                .FirstOrDefaultAsync(m => m.id_solicitud == id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // GET: Solicitudes/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Solicitudes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_solicitud,fecha_realiza,fecha_recibe,sede_recibe,nombre_persona_recibe,metodo_envio,apoyo_organizativo,producto_apoyo_organizativo,servicio_apoyo_empleados,servicio_apoyo_recibe,servicio_apoyo_recibe_region_educativa,apoyo_educativo_requerido,descripcion_condicion,id_centro_Educativo,id_historial")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {

                if (solicitud.solicitud_archivo.Count > 0)
                {
                    foreach (var archivo in solicitud.solicitud_archivo)
                    {
                        // crea la ruta en la carpeta wwwroot para guardar el archivo en el servidor
                        string ruta = Path.Combine(Directory.GetCurrentDirectory(), solicitud.id_solicitud + "wwwroot/Archivos");

                        // crea la carpeta si no existe
                        if (!Directory.Exists(ruta))
                        {
                            Directory.CreateDirectory(ruta);
                        }

                        string archivo_nombre_con_ruta = Path.Combine(ruta, archivo.id_archivoNavigation.FileName);

                        using (var stream = new FileStream(archivo_nombre_con_ruta, FileMode.Create))
                        {
                            archivo.id_archivoNavigation.CopyTo(stream);
                        }

                        var archivo1 = new Archivo()
                        {
                            FileName = archivo.id_archivoNavigation.FileName,
                            ruta = archivo_nombre_con_ruta,
                            Length = archivo.id_archivoNavigation.Length
                        };

                        _context.Add(archivo1);

                        var solicitud_archivo = new SolicitudArchivo()
                        {
                            id_solicitud = solicitud.id_solicitud,
                            id_archivo = archivo1.archivo_id
                        };

                        _context.Add(solicitud_archivo);
                    }
                }

                _context.Add(solicitud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Indice));
            }
            return View(solicitud);
        }

        // GET: Solicitudes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Solicitud == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud.FindAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }
            return View(solicitud);
        }

        // POST: Solicitudes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_solicitud,fecha_realiza,fecha_recibe,sede_recibe,nombre_persona_recibe,metodo_envio,apoyo_organizativo,producto_apoyo_organizativo,servicio_apoyo_empleados,servicio_apoyo_recibe,servicio_apoyo_recibe_region_educativa,apoyo_educativo_requerido,descripcion_condicion,id_centro_Educativo,id_historial")] Solicitud solicitud)
        {
            if (id != solicitud.id_solicitud)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitudExists(solicitud.id_solicitud))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Indice));
            }
            return View(solicitud);
        }

        // GET: Solicitudes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Solicitud == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud
                .FirstOrDefaultAsync(m => m.id_solicitud == id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // POST: Solicitudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Solicitud == null)
            {
                return Problem("Entity set 'ProyectoSadasContexto.Solicitud'  is null.");
            }
            var solicitud = await _context.Solicitud.FindAsync(id);
            if (solicitud != null)
            {
                _context.Solicitud.Remove(solicitud);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Indice));
        }

        private bool SolicitudExists(int id)
        {
            return _context.Solicitud.Any(e => e.id_solicitud == id);
        }
    }
}
