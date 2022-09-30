using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Sadas.Models
{
    [Table("historial")]
    public class Historial
    {
        [Key]
        public int id_historial { get; set; }
        public int asesoria_previa { get; set; }
        public string sede_asesoria_previa { get; set; }
        public int adjunta_certificacion_medica_CCSS { get; set; }
        public int adjunta_certificacion_medica_CONAPDIS { get; set; }
        public int producto_apoyo_gubernamental { get; set; }
        public string producto_apoyo_gubernamental_descripcion { get; set; }
        public int producto_apoyo_no_gubernamental { get; set; }
        public string producto_apoyo_no_gubernamental_descripcion { get; set; }

        public ICollection<Solicitud> solicitudes { get; set; } = default!;
    }
}
