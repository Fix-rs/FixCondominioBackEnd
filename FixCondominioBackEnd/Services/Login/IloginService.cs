using FixCondominioBackEnd.Models;
using FixCondominioBackEnd.Models.InputModels;
using FixCondominioBackEnd.Models.ViewModels;
using FixCondominioBackEnd.Repositories;

namespace FixCondominioBackEnd.Services.Login
{
    public interface ILoginService
    {
        Task<UsuarioModel> CarregarUsuario(InputLoginModel inputLoginModel);
        ViewUsuarioModel GerarToken(UsuarioModel usuarioModel);
    }
    public class LoginService : ILoginService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioModel> CarregarUsuario(InputLoginModel inputLoginModel)
        {
            var userModel = await _usuarioRepository.GetByUserAndPasswordAsync(inputLoginModel);
            if(userModel != null)
                return userModel;
            
            return null;
        }

        public ViewUsuarioModel GerarToken(UsuarioModel usuarioModel)
        {
            return TokenService.GenerateTokem(usuarioModel);
        }
    }
}
