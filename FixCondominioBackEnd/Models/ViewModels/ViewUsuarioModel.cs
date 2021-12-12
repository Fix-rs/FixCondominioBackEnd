namespace FixCondominioBackEnd.Models.ViewModels
{
    public class ViewUsuarioModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Regra { get; set; }
        public string Token { get; set; }

        public static implicit operator ViewUsuarioModel(UsuarioModel usuarioModel)
        {
            return new ViewUsuarioModel()
            {
                ID = usuarioModel.ID,
                Name = usuarioModel.Nome,
                Regra = usuarioModel.Regra
            };
        }

    }
}
