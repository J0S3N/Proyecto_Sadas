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
        public async Task<IActionResult> Consultar()
        {
            return View(await _context.Solicitud.ToListAsync());
        }

        // GET: Solicitudes/Detalle/5
        public async Task<IActionResult> Detalle(int? id)
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

        // GET: Solicitudes/Registrar
        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }


        // POST: Solicitudes/Registrar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(
            [Bind("id_solicitud,fecha_solicit  ud,fecha_respuesta,estado,observaciones,id_centro_Educativo,id_historial")] Solicitud solicitud, Historial historial,
            CentroEducativo centroEducativo, Persona estudiante, Persona docente, Persona madre, Persona padre, Persona solicitante, Persona encargado)
        {

            estudiante.tipo_persona = "Estudiante";
            docente.tipo_persona = "Docente";
            madre.tipo_persona = "Madre";
            padre.tipo_persona = "Padre";
            solicitante.tipo_persona = "Solicitante";
            encargado.tipo_persona = "Encargado";

            SolicitudPersona p1 = new SolicitudPersona()
            {
                id_solicitud = solicitud.id_solicitud,
                id_persona = estudiante.id_persona,
            };

            SolicitudPersona p2 = new SolicitudPersona()
            {
                id_solicitud = solicitud.id_solicitud,
                id_persona = docente.id_persona,
            };

            SolicitudPersona p3 = new SolicitudPersona()
            {
                id_solicitud = solicitud.id_solicitud,
                id_persona = madre.id_persona,
            };

            SolicitudPersona p4 = new SolicitudPersona()
            {
                id_solicitud = solicitud.id_solicitud,
                id_persona = padre.id_persona,
            };

            SolicitudPersona p5 = new SolicitudPersona()
            {
                id_solicitud = solicitud.id_solicitud,
                id_persona = solicitante.id_persona,
            };

            SolicitudPersona p6 = new SolicitudPersona()
            {
                id_solicitud = solicitud.id_solicitud,
                id_persona = encargado.id_persona,
            };

            if (ModelState.IsValid)
            {
                _context.Add(p1);
                _context.Add(p2);
                _context.Add(p3);
                _context.Add(p4);
                _context.Add(p5);
                _context.Add(p6);
                _context.Add(solicitud);
                _context.Add(historial);
                _context.Add(centroEducativo);
                _context.Add(estudiante);
                _context.Add(docente);
                _context.Add(madre);
                _context.Add(padre);
                _context.Add(solicitante);
                _context.Add(encargado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Consultar));
            }

            /*
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
                return RedirectToAction(nameof(Consultar));
            }
            */
            return View();
        }


        // GET: Solicitudes/Modificar/5
        public async Task<IActionResult> Modificar(int? id)
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

        // POST: Solicitudes/Modificar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modificar(int id, [Bind("id_solicitud,fecha_realiza,fecha_recibe,sede_recibe,nombre_persona_recibe,metodo_envio,apoyo_organizativo,producto_apoyo_organizativo,servicio_apoyo_empleados,servicio_apoyo_recibe,servicio_apoyo_recibe_region_educativa,apoyo_educativo_requerido,descripcion_condicion,id_centro_Educativo,id_historial")] Solicitud solicitud)
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
                return RedirectToAction(nameof(Consultar));
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
            return RedirectToAction(nameof(Consultar));
        }

        private bool SolicitudExists(int id)
        {
            return _context.Solicitud.Any(e => e.id_solicitud == id);
        }
    }
}
