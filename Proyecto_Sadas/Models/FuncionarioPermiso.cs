using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Sadas.Models
{
    [Table("funcionario_permiso")]
    public class FuncionarioPermiso
    {
        public int id_funcionario { get; set; }
        public int id_permiso { get; set; }
        public Funcionario id_funcionarioNavigation { get; set; } = default!;
        public Permiso id_permisoNavigation { get; set; } = default!;
    }
}
