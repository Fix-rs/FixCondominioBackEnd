using System.ComponentModel.DataAnnotations;

namespace FixCondominioBackEnd.Models
{
    public class UsuarioModel
    {
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Enum.EnumRole Regra { get; set; } = Enum.EnumRole.User;
        public DateTime DataAlteracao { get; set; }
    }
}
