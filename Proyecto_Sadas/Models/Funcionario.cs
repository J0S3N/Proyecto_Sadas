using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Proyecto_Sadas.Models
{
    [Table("funcionario")]
    public class Funcionario
    {
        [Key]
        public int id_funcionario { get; set; }
        public string tipo_cedula { get; set; }
        public string numero_cedula { get; set; }
        public string nombre { get; set; }
        public string apellido_1 { get; set; }
        public string apellido_2 { get; set; }
        public string telefono_1 { get; set; }
        public string telefono_2 { get; set; }
        public string correo_1 { get; set; }
        public string correo_2 { get; set; }
        public string usuario { get; set; }
        public string contrasenna { get; set; }
        public string sede_trabajo { get; set; }

        public IList<FuncionarioPermiso> funcionario_permiso { get; set; } = default!;

        public IList<SolicitudFuncionario> solicitud_funcionario { get; set; }
    }
}
