using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

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
