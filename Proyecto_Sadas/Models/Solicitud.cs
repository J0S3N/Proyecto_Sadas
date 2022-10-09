using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Proyecto_Sadas.Models
{

    [Table("solicitud")]
    public class Solicitud
    {
        [Key]
        public int id_solicitud { get; set; }
        public DateTime fecha_realiza { get; set; }
        public DateTime fecha_recibe { get; set; }
        public string sede_recibe { get; set; }
        public string nombre_persona_recibe { get; set; }
        public string metodo_envio { get; set; }
        public string apoyo_organizativo { get; set; }
        public string producto_apoyo_organizativo { get; set; }
        public string servicio_apoyo_empleados { get; set; }
        public string servicio_apoyo_recibe { get; set; }
        public string servicio_apoyo_recibe_region_educativa { get; set; }
        public string apoyo_educativo_requerido { get; set; }
        public string descripcion_condicion { get; set; }

        [ForeignKey("id_centro_educativo")]
        public int id_centro_Educativo { get; set; }
        public CentroEducativo centro_Educativo { get; set; }

        [ForeignKey("id_historial")]
        public int id_historial { get; set; }
        public Historial historial { get; set; }

        public IList<SolicitudArchivo> solicitud_archivo { get; set; } = default!;
        public IList<SolicitudPersona> solicitud_persona { get; set; } = default!;
        public IList<SolicitudFuncionario> solicitud_funcionario { get; set; } = default!;
        public IList<SolicitudAuditoria> solicitud_auditoria { get; set; } = default!;

        public Persona docente { get; set; } = default!;
        public Persona estudiante { get; set; } = default!;
        public Persona solicitante { get; set; } = default!;
        public Persona madre { get; set; } = default!;
        public Persona padre { get; set; } = default!;
        public Persona encargado { get; set; } = default!;

    }
}
