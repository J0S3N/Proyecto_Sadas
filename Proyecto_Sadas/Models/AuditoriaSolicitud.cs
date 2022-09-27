using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Sadas.Models
{
    [Table("auditoria_solicitud")]
    public class AuditoriaSolicitud
    {
        [Key]
        public int id_auditoria { get; set; }
        public string modificado_por { get; set; }
        public string razon_modificacion { get; set; }
        public DateTime fecha { get; set; }
        public IList<SolicitudAuditoria> solicitud_auditoria { get; set; }
    }
}
