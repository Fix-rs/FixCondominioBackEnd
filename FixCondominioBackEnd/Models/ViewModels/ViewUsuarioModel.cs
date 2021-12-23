namespace FixCondominioBackEnd.Models.ViewModels
{
    public class ViewUsuarioModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

        public static implicit operator ViewUsuarioModel(UsuarioModel usuarioModel)
        {
            return new ViewUsuarioModel()
            {
                ID = usuarioModel.ID,
                Nome = usuarioModel.Nome,
                Role = usuarioModel.Regra
            };
        }

    }
}
