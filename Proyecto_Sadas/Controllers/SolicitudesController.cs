using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Sadas.Data;
using Proyecto_Sadas.Models;
using System.Net.Http;

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
        public async Task<IActionResult> Registrar(IFormCollection formCollection)
        {

            //dynamic expando object
            //falta guardar solicitud...
            //falta save changes

            Solicitud solicitud = new Solicitud()
            {
                fecha_realiza = Convert.ToDateTime(formCollection["fecha_realiza"]),
                fecha_recibe = Convert.ToDateTime(formCollection["fecha_recibe"]),
                sede_recibe = formCollection["sede_recibe"],
                nombre_persona_recibe = formCollection["nombre_persona_recibe"],
                metodo_envio = formCollection["metodo_envio"],
                apoyo_organizativo = formCollection["apoyo_organizativo"],
                producto_apoyo_organizativo = formCollection["producto_apoyo_organizativo"],
                servicio_apoyo_empleados = formCollection["servicio_apoyo_empleados"],
                servicio_apoyo_recibe = formCollection["servicio_apoyo_recibe"],
                servicio_apoyo_recibe_region_educativa = formCollection["servicio_apoyo_recibe_region_educativa"],
                apoyo_educativo_requerido = formCollection["apoyo_educativo_requerido"],
                descripcion_condicion = formCollection["descripcion_condicion"]
            };

            _context.Add(solicitud);

            Persona estudiante = new Persona();
            estudiante.tipo_cedula = formCollection["tipo_cedula_estudiante"];
            estudiante.numero_cedula = formCollection["numero_cedula_estudiante"];
            estudiante.tipo_persona = "Estudiante";
            estudiante.nombre = formCollection["nombre_estudiante"];
            estudiante.apellido_1 = formCollection["apellido_1_estudiante"];
            estudiante.apellido_2 = formCollection["apellido_2_estudiante"];
            estudiante.telefono_1 = Convert.ToInt32(formCollection["telefono_1_estudiante"]);
            estudiante.telefono_2 = Convert.ToInt32(formCollection["telefono_2_estudiante"]);
            estudiante.correo_1 = formCollection["correo_1_estudiante"];
            estudiante.correo_2 = formCollection["correo_2_estudiante"];
            estudiante.fecha_nacimiento_estudiante = Convert.ToDateTime(formCollection["fecha_nacimiento_estudiante"]);
            estudiante.nivel_educativo_estudiante = formCollection["nivel_educativo_estudiante"];
            estudiante.provincia_estudiante = formCollection["provincia_estudiante"];
            estudiante.canton_estudiante = formCollection["canton_estudiante"];
            estudiante.distrito_estudiante = formCollection["distrito_estudiante"];
            estudiante.ubicacion_exacta_estudiante = formCollection["ubicacion_exacta_estudiante"];
            estudiante.observaciones_estudiante = formCollection["observaciones_estudiante"];

            _context.Add(estudiante);

            SolicitudPersona p1 = new SolicitudPersona()
            {
            id_solicitud = solicitud.id_solicitud,
            id_persona = estudiante.id_persona,
            };

            _context.Add(p1);

            Persona madre = new Persona() {
                tipo_cedula = formCollection["tipo_cedula_madre"],
                numero_cedula = formCollection["numero_cedula_madre"],
                tipo_persona = "Madre",
                nombre = formCollection["nombre_madre"],
                apellido_1 = formCollection["apellido_1_madre"],
                apellido_2 = formCollection["apellido_2_madre"],
                telefono_1 = Convert.ToInt32(formCollection["telefono_1_madre"]),
                telefono_2 = Convert.ToInt32(formCollection["telefono_2_madre"]),
                correo_1 = formCollection["correo_1_madre"],
                correo_2 = formCollection["correo_2_madre"],                                
            };

            _context.Add(madre);

            SolicitudPersona p2 = new SolicitudPersona()
            {
            id_solicitud = solicitud.id_solicitud,
            id_persona = madre.id_persona,
            };

            _context.Add(p2);

            Persona padre = new() {
                tipo_cedula = formCollection["tipo_cedula_padre"],
                numero_cedula = formCollection["numero_cedula_padre"],
                tipo_persona = "Padre",
                nombre = formCollection["nombre_padre"],
                apellido_1 = formCollection["apellido_1_padre"],
                apellido_2 = formCollection["apellido_2_padre"],
                telefono_1 = Convert.ToInt32(formCollection["telefono_1_padre"]),
                telefono_2 = Convert.ToInt32(formCollection["telefono_2_padre"]),
                correo_1 = formCollection["correo_1_padre"],
                correo_2 = formCollection["correo_2_padre"],
            };

            _context.Add(padre);

            SolicitudPersona p3 = new SolicitudPersona()
            {
            id_solicitud = solicitud.id_solicitud,
            id_persona = padre.id_persona,
            };

            _context.Add(p3);

            Persona encargado = new Persona() {
                tipo_cedula = formCollection["tipo_cedula_encargado"],
                numero_cedula = formCollection["numero_cedula_encargado"],
                tipo_persona = "Encargado",
                nombre = formCollection["nombre_encargado"],
                apellido_1 = formCollection["apellido_1_encargado"],
                apellido_2 = formCollection["apellido_2_encargado"],
                telefono_1 = Convert.ToInt32(formCollection["telefono_1_encargado"]),
                telefono_2 = Convert.ToInt32(formCollection["telefono_2_encargado"]),
                correo_1 = formCollection["correo_1_encargado"],
                correo_2 = formCollection["correo_2_encargado"],
                parenstesco_encargado = formCollection["parentesco_encargardo"],
            };

            _context.Add(encargado);

            SolicitudPersona p4 = new SolicitudPersona()
            {
                id_solicitud = solicitud.id_solicitud,
                id_persona = encargado.id_persona,
            };

            _context.Add(p4);

            Persona docente = new Persona() {
                tipo_cedula = formCollection["tipo_cedula_docente"],
                numero_cedula = formCollection["numero_cedula_docente"],
                tipo_persona = "Docente",
                nombre = formCollection["nombre_docente"],
                apellido_1 = formCollection["apellido_1_docente"],
                apellido_2 = formCollection["apellido_2_docente"],
                telefono_1 = Convert.ToInt32(formCollection["telefono_1_docente"]),
                telefono_2 = Convert.ToInt32(formCollection["telefono_2_docente"]),
                correo_1 = formCollection["correo_1_docente"],
                correo_2 = formCollection["correo_2_docente"]
            };

            _context.Add(docente);

            SolicitudPersona p5 = new SolicitudPersona()
            {
                id_solicitud = solicitud.id_solicitud,
                id_persona = docente.id_persona,
            };

            _context.Add(p5);

            Persona solicitante = new Persona() {
                tipo_cedula = formCollection["tipo_cedula_solicitante"],
                numero_cedula = formCollection["numero_cedula_solicitante"],
                tipo_persona = "Solicitante",
                nombre = formCollection["nombre_solicitante"],
                apellido_1 = formCollection["apellido_1_solicitante"],
                apellido_2 = formCollection["apellido_2_solicitante"],
                telefono_1 = Convert.ToInt32(formCollection["telefono_1_solicitante"]),
                telefono_2 = Convert.ToInt32(formCollection["telefono_2_solicitante"]),
                correo_1 = formCollection["correo_1_solicitante"],
                correo_2 = formCollection["correo_2_solicitante"],
                relacion_solicitante = formCollection["relacion_solicitante"],
            };

            _context.Add(solicitante);

            SolicitudPersona p6 = new SolicitudPersona()
            {
                id_solicitud = solicitud.id_solicitud,
                id_persona = solicitante.id_persona,
            };

            _context.Add(p6);

            CentroEducativo centroEducativo = new CentroEducativo() {
                nombre = formCollection["nombre_centro_educativo"],
                telefono_1 = Convert.ToInt32(formCollection["telefono_1_centro_educativo"]),
                telefono_2 = Convert.ToInt32(formCollection["telefono_2_centro_educativo"]),
                correo_2 = formCollection["correo_1_centro_educativo"],
                correo_1 = formCollection["correo_2_centro_educativo"],
                dependencia = formCollection["dependencia"],
                region_educativa = formCollection["region_educativa"],
                provincia = formCollection["provincia_centro_educativo"],
                canton = formCollection["canton_centro_educativo"],
                distrito = formCollection["distrito_centro_educativo"],
                ubicacion_exacta = formCollection["ubicacion_exacta_centro_educativo"],
                circuito = formCollection["circuito"],
                encargado = formCollection["encargado"],
            };

            solicitud.id_centro_Educativo = centroEducativo.id_centro_educativo;

            Historial historial = new Historial()
            {  
                asesoria_previa = Convert.ToInt16(formCollection["asesoria_previa"]),
                sede_asesoria_previa = formCollection["sede_asesoria_previa"],
                adjunta_certificacion_medica_CCSS = Convert.ToInt16(formCollection["adjunta_certificacion_medica_CCSS"]),
                adjunta_certificacion_medica_CONAPDIS = Convert.ToInt16(formCollection["adjunta_certificacion_medica_CONAPDIS"]),
                producto_apoyo_gubernamental = Convert.ToInt16(formCollection["producto_apoyo_gubernamental"]),
                producto_apoyo_gubernamental_descripcion = formCollection["producto_apoyo_gubernamental_descripcion"],
                producto_apoyo_no_gubernamental = Convert.ToInt16(formCollection["producto_apoyo_no_gubernamental"]),
                producto_apoyo_no_gubernamental_descripcion = formCollection["producto_apoyo_no_gubernamental_descripcion"],
            };
            
            solicitud.id_historial = historial.id_historial;

            _context.Add(solicitud);
                
            _context.Add(historial);
                
            _context.Add(centroEducativo);
                
            await _context.SaveChangesAsync();
                
            return RedirectToAction(nameof(Consultar));


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
