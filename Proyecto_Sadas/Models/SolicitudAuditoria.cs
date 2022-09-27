using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Sadas.Models
{
    [Table("solicitud_auditoria")]
    public class SolicitudAuditoria
    {
        public int id_solicitud { get; set; }
        public int id_auditoria { get; set; }
        public Solicitud id_solicitudNavigation { get; set; } = default!;
        public AuditoriaSolicitud id_auditoriaNavigation { get; set; } = default!;

    }
}
