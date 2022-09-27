using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Sadas.Models
{
    [Table("solicitud_persona")]
    public class SolicitudPersona
    {
        public int id_solicitud { get; set; }
        public int id_persona { get; set; }
        public Solicitud id_solicitudNavigation { get; set; } = default!;
        public Persona id_personaNavigation { get; set; } = default!;
    }
}
