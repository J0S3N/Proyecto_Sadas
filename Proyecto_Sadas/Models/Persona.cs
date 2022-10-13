using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Proyecto_Sadas.Models
{
    [Table("persona")]
    public class Persona
    {
        [Key]
        public int id_persona { get; set; }
        public string? tipo_cedula { get; set; }
        public string? numero_cedula { get; set; }
        public string? tipo_persona { get; set; }
        public string? nombre { get; set; }
        public string? apellido_1 { get; set; }
        public string? apellido_2 { get; set; }
        [Phone]
        public int? telefono_1 { get; set; }
        [Phone]
        public int? telefono_2 { get; set; }
        [EmailAddress]
        public string? correo_1 { get; set; }
        [EmailAddress]
        public string? correo_2 { get; set; }
        public string? parenstesco_encargado { get; set; }
        public int? prioridad_encargado { get; set; }
        public DateTime? fecha_nacimiento_estudiante { get; set; }
        public string? nivel_educativo_estudiante { get; set; }
        public string? provincia_estudiante { get; set; }
        public string? canton_estudiante { get; set; }
        public string? distrito_estudiante { get; set; }
        public string? ubicacion_exacta_estudiante { get; set; }
        public string? observaciones_estudiante { get; set; }
        public string? relacion_solicitante { get; set; }
        public string? otro_anote_solicitante { get; set; }
        public IList<SolicitudPersona>? solicitud_persona { get; set; } = default!;

    }
}
