using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Sadas.Models
{
    [Table("solicitud_funcionario")]
    public class SolicitudFuncionario
    {
        public int id_solicitud { get; set; }
        public int id_funcionario { get; set; }
        public Solicitud id_solicitudNavigation { get; set; } = default!;
        public Funcionario id_funcionarioNavigation { get; set; } = default!;
        
    }
}
