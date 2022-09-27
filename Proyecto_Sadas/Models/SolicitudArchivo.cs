using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Sadas.Models
{
    [Table("solicitud_archivo")]
    public class SolicitudArchivo
    {
        public int id_solicitud { get; set; }
        public int id_archivo { get; set; }
        public Solicitud id_solicitudNavigation { get; set; } = default!;
        public Archivo id_archivoNavigation { get; set; } = default!;
    }
}
