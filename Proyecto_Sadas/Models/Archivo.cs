using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Sadas.Models
{
    [Table("archivo")]
    public class Archivo
    {
        [Key]
        public int archivo_id { get; set; }
        public string nombre { get; set; }
        public string ruta { get; set; }
        public string tamanno { get; set; }
        public IList<SolicitudArchivo> solicitud_archivo { get; set; } = default!;
    }
}
