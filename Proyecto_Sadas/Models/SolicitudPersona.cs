using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Sadas.Models
{
    [Table("solicitud_persona")]
    public class SolicitudPersona
    {
        public int id_solicitud { get; set; } //IdSolicitud
        public int id_persona { get; set; } //IdPersona

    }
}
