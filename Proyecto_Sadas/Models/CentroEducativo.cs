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
    [Table("centro_educativo")]
    public class CentroEducativo
    {
        [Key]
        public int id_centro_educativo { get; set; }
        public string nombre { get; set; }
        public int telefono_1 { get; set; }
        public int telefono_2 { get; set; }
        public string correo_1 { get; set; }
        public string correo_2 { get; set; }
        public string dependencia { get; set; }
        public string region_educativa { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public string ubicacion_exacta { get; set; }
        public string circuito { get; set; }
        public string encargado { get; set; }

        public ICollection<Solicitud> solicitudes { get; set; } = default!;
    }
}