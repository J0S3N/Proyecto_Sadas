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

    [Table("permiso")]
    public class Permiso
    {
        [Key]
        public int id_permiso { get; set; }
        public string nombre { get; set; }
        public string detalle { get; set; }

        public IList<FuncionarioPermiso> Funcionario_permiso { get; set; } = default!;
    }
}
