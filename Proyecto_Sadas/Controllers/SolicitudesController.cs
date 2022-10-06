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
            //[Bind("id_historial", "asesoria_previa", "sede_asesoria_previa", "adjunta_certificacion_medica_CCSS", "adjunta_certificacion_medica_CONAPDIS", "producto_apoyo_gubernamental", "producto_apoyo_gubernamental_descripcion", "producto_apoyo_no_gubernamental", "producto_apoyo_no_gubernamental_descripcion")] Historial historial,
            //[Bind("id_centro_educativo", "nombre_centro_educativo", "telefono_1_centro_educativo", "telefono_2_centro_educativo", "correo_1_centro_educativo", "correo_2_centro_educativo", "dependencia", "region_educativa", "provincia_region_educativa", "canton_region_educativa", "distrito_region_educativa", "ubicacion_exacta_region_educativa", "circuito", "encargado_centro_educativo")] CentroEducativo centroEducativo,
            DateTime fecha_realiza, 
            DateTime fecha_recibe, 
            string sede_recibe, 
            string nombre_persona_recibe, 
            string metodo_envio, 
            string apoyo_organizativo, 
            string producto_apoyo_organizativo, 
            string servicio_apoyo_empleados, 
            string servicio_apoyo_recibe, 
            string servicio_apoyo_recibe_region_educativa, 
            string apoyo_educativo_requerido, 
            string descripcion_condicion, 
            
            int asesoria_previa, 
            string sede_asesoria_previa, 
            int adjunta_certificacion_medica_CCSS, 
            int adjunta_certificacion_medica_CONAPDIS, 
            int producto_apoyo_gubernamental, 
            string producto_apoyo_gubernamental_descripcion, 
            int producto_apoyo_no_gubernamental, 
            string producto_apoyo_no_gubernamental_descripcion, 
            
            string nombre_centro_educativo, 
            int telefono_1_centro_educativo, 
            int telefono_2_centro_educativo, 
            string correo_1_centro_educativo, 
            string correo_2_centro_educativo, 
            string dependencia, 
            string region_educativa, 
            string provincia_region_educativa, 
            string canton_region_educativa, 
            string distrito_region_educativa, 
            string ubicacion_exacta_region_educativa, 
            string circuito, 
            string encargado_centro_educativo,
            
            string tipo_cedula_estudiante,
            string numero_cedula_estudiante,
            string nombre_estudiante,
            string apellido1_estudiante,
            string apellido2_estudiante,
            int telefono_1_estudiante,
            int telefono_2_estudiante,
            string correo_1_estudiante,
            string correo_2_estudiante,
            DateTime fecha_nacimiento_estudiante,
            string nivel_educativo_estudiante,
            string provincia_estudiante,
            string canton_estudiante,
            string distrito_estudiante,
            string ubicacion_exacta_estudiante,
            string observaciones_estudiante,

            string tipo_cedula_padre,
            string numero_cedula_padre,
            string nombre_padre,
            string apellido1_padre,
            string apellido2_padre,
            int telefono_1_padre,
            int telefono_2_padre,
            string correo_1_padre,
            string correo_2_padre,

            string tipo_cedula_madre,
            string numero_cedula_madre,
            string nombre_madre,
            string apellido_1_madre,
            string apellido_2_madre,
            int telefono_1_madre,
            int telefono_2_madre,
            string correo_1_madre,
            string correo_2_madre,

            string tipo_cedula_encargado,
            string numero_cedula_encargado,
            string nombre_encargado,
            string apellido1_encargado,
            string apellido2_encargado,
            int telefono_1_encargado,
            int telefono_2_encargado,
            string correo_1_encargado,
            string correo_2_encargado,
            string parentesco_encargado,

            string tipo_cedula_docente,
            string numero_cedula_docente,
            string nombre_docente,
            string apellido1_docente,
            string apellido2_docente,
            int telefono_1_docente,
            int telefono_2_docente,
            string correo_1_docente,
            string correo_2_docente,

            string tipo_cedula_solicitante,
            string numero_cedula_solicitante,
            string nombre_solicitante,
            string apellido_1_solicitante,
            string apellido_2_solicitante,
            int telefono_1_solicitante,
            int telefono_2_solicitante,
            string correo_1_solicitante,
            string correo_2_solicitante,
            string puesto_desenpena
            )
        {
            CentroEducativo centroEducativo = new CentroEducativo() {
                nombre = nombre_centro_educativo,
                telefono_1 = telefono_1_centro_educativo,
                telefono_2 = telefono_2_centro_educativo,
                correo_1 = correo_1_centro_educativo,
                correo_2 = correo_2_centro_educativo,
                dependencia = dependencia,
                region_educativa = region_educativa,
                provincia = provincia_region_educativa,
                canton = canton_region_educativa,
                distrito = distrito_region_educativa,
                ubicacion_exacta = ubicacion_exacta_region_educativa,
                circuito = circuito,
                encargado = encargado_centro_educativo
            };

            _context.Add(centroEducativo);
            
            Historial historial = new Historial() {
                asesoria_previa = asesoria_previa,
                sede_asesoria_previa = sede_asesoria_previa,
                adjunta_certificacion_medica_CCSS = adjunta_certificacion_medica_CCSS,
                adjunta_certificacion_medica_CONAPDIS = adjunta_certificacion_medica_CONAPDIS,
                producto_apoyo_gubernamental = producto_apoyo_gubernamental,
                producto_apoyo_gubernamental_descripcion = producto_apoyo_gubernamental_descripcion,
                producto_apoyo_no_gubernamental = producto_apoyo_no_gubernamental,
                producto_apoyo_no_gubernamental_descripcion = producto_apoyo_no_gubernamental_descripcion
            };

            _context.Add(historial);
            
            Solicitud solicitud = new Solicitud() {
                fecha_realiza = fecha_realiza,
                fecha_recibe = fecha_recibe,
                sede_recibe = sede_recibe,
                nombre_persona_recibe = nombre_persona_recibe,
                metodo_envio = metodo_envio,
                apoyo_organizativo = apoyo_organizativo,
                producto_apoyo_organizativo = producto_apoyo_organizativo,
                descripcion_condicion = descripcion_condicion,
                apoyo_educativo_requerido = apoyo_educativo_requerido,
                id_historial = historial.id_historial,
                id_centro_Educativo = centroEducativo.id_centro_educativo
            };

            Persona estudiante = new Persona
            {
                tipo_cedula = tipo_cedula_estudiante,
                numero_cedula = numero_cedula_estudiante,
                tipo_persona = "Estudiante",
                nombre = nombre_estudiante,
                apellido_1 = apellido1_estudiante,
                apellido_2 = apellido2_estudiante,
                telefono_1 = telefono_1_estudiante,
                telefono_2 = telefono_2_estudiante,
                correo_1 = correo_1_estudiante,
                correo_2 = correo_2_estudiante,
                parenstesco_encargado = "",
                prioridad_encargado = 0,
                fecha_nacimiento_estudiante = fecha_nacimiento_estudiante,
                nivel_educativo_estudiante = nivel_educativo_estudiante,
                provincia_estudiante = provincia_estudiante,
                canton_estudiante = canton_estudiante,
                distrito_estudiante = distrito_estudiante,
                ubicacion_exacta_estudiante = ubicacion_exacta_estudiante,
                observaciones_estudiante = observaciones_estudiante,
                relacion_solicitante = "",
                otro_anote_solicitante = ""
            };

            Persona madre = new Persona
            {
                tipo_cedula = tipo_cedula_madre,
                numero_cedula = numero_cedula_madre,
                tipo_persona = "Madre",
                nombre = nombre_madre,
                apellido_1 = apellido_1_madre,
                apellido_2 = apellido_2_madre,
                telefono_1 = telefono_1_madre,
                telefono_2 = telefono_2_madre,
                correo_1 = correo_1_madre,
                correo_2 = correo_2_madre,
                parenstesco_encargado = "",
                prioridad_encargado = 0,
                fecha_nacimiento_estudiante = Convert.ToDateTime("00/00/2000"),
                nivel_educativo_estudiante = "",
                provincia_estudiante = "",
                canton_estudiante = "",
                distrito_estudiante = "",
                ubicacion_exacta_estudiante = "",
                observaciones_estudiante = "",
                relacion_solicitante = "",
                otro_anote_solicitante = ""
            };

            Persona padre = new Persona
            {
                tipo_cedula = tipo_cedula_padre,
                numero_cedula = numero_cedula_padre,
                tipo_persona = "Padre",
                nombre = nombre_padre,
                apellido_1 = apellido1_padre,
                apellido_2 = apellido2_padre,
                telefono_1 = telefono_1_padre,
                telefono_2 = telefono_2_padre,
                correo_1 = correo_1_padre,
                correo_2 = correo_2_padre,
                parenstesco_encargado = "",
                prioridad_encargado = 0,
                fecha_nacimiento_estudiante = Convert.ToDateTime("00/00/2000"),
                nivel_educativo_estudiante = "",
                provincia_estudiante = "",
                canton_estudiante = "",
                distrito_estudiante = "",
                ubicacion_exacta_estudiante = "",
                observaciones_estudiante = "",
                relacion_solicitante = "",
                otro_anote_solicitante = ""
            };

            Persona docente = new Persona
            {
                tipo_cedula = tipo_cedula_docente,
                numero_cedula = numero_cedula_docente,
                tipo_persona = "Docente",
                nombre = nombre_docente,
                apellido_1 = apellido1_docente,
                apellido_2 = apellido2_docente,
                telefono_1 = telefono_1_docente,
                telefono_2 = telefono_2_docente,
                correo_1 = correo_1_docente,
                correo_2 = correo_2_docente,
                parenstesco_encargado = "",
                prioridad_encargado = 0,
                fecha_nacimiento_estudiante = Convert.ToDateTime("00/00/2000"),
                nivel_educativo_estudiante = "",
                provincia_estudiante = "",
                canton_estudiante = "",
                distrito_estudiante = "",
                ubicacion_exacta_estudiante = "",
                observaciones_estudiante = "",
                relacion_solicitante = "",
                otro_anote_solicitante = ""
            };

            Persona solicitante = new Persona
            {
                tipo_cedula = tipo_cedula_solicitante,
                numero_cedula = numero_cedula_solicitante,
                tipo_persona = "Solicitante",
                nombre = nombre_solicitante,
                apellido_1 = apellido_1_solicitante,
                apellido_2 = apellido_2_solicitante,
                telefono_1 = telefono_1_solicitante,
                telefono_2 = telefono_2_solicitante,
                correo_1 = correo_1_solicitante,
                correo_2 = correo_2_solicitante,
                parenstesco_encargado = "",
                prioridad_encargado = 0,
                fecha_nacimiento_estudiante = Convert.ToDateTime("00/00/2000"),
                nivel_educativo_estudiante = "",
                provincia_estudiante = "",
                canton_estudiante = "",
                distrito_estudiante = "",
                ubicacion_exacta_estudiante = "",
                observaciones_estudiante = puesto_desenpena,
                relacion_solicitante = "",
                otro_anote_solicitante = ""
            };

            Persona encargado = new Persona
            {
                tipo_cedula = tipo_cedula_encargado,
                numero_cedula = numero_cedula_encargado,
                tipo_persona = "Encargado",
                nombre = nombre_encargado,
                apellido_1 = apellido1_encargado,
                apellido_2 = apellido2_encargado,
                telefono_1 = telefono_1_encargado,
                telefono_2 = telefono_2_encargado,
                correo_1 = correo_1_encargado,
                correo_2 = correo_2_encargado,
                parenstesco_encargado = parentesco_encargado,
                prioridad_encargado = 1,
                fecha_nacimiento_estudiante = Convert.ToDateTime("00/00/2000"),
                nivel_educativo_estudiante = "",
                provincia_estudiante = "",
                canton_estudiante = "",
                distrito_estudiante = "",
                ubicacion_exacta_estudiante = "",
                observaciones_estudiante = "",
                relacion_solicitante = "",
                otro_anote_solicitante = ""
            };

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
            return View(solicitud);
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
