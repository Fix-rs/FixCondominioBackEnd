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
        public string Regra { get; set; } = "user";
        public DateTime DataAlteracao { get; set; }
    }
}
