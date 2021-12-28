namespace FixCondominioBackEnd.Models.ViewModels
{
    public class ViewUsuarioModel
    {
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public Enum.EnumRole Role { get; set; }
        public string Token { get; set; } = string.Empty;

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
