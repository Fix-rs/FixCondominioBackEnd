using FixCondominioBackEnd.Models;
using FixCondominioBackEnd.Models.InputModels;
using FixCondominioBackEnd.Repositories;

namespace FixCondominioBackEnd.Services.Usuario
{
    public interface IContaUsuarioService
    {
        InputUsuarioModel ValidaDados(InputUsuarioModel user);
        Task<dynamic> VerificaSeJaExiste(InputUsuarioModel user);
        Task<UsuarioModel> InserirNovoUsuario(InputUsuarioModel user);
        Task<string> AtualizarTabelas();

    }
    public class ContaUsuarioService : IContaUsuarioService
    {
        private readonly IUsuarioRepository _userRepository;

        public ContaUsuarioService(IUsuarioRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public InputUsuarioModel ValidaDados(InputUsuarioModel user)
        {
            if (user != null && !string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Senha) && !string.IsNullOrEmpty(user.Nome))
            {
                return user;
            }
            return null;
        }

        public async Task<dynamic> VerificaSeJaExiste(InputUsuarioModel user)
        {
            try
            {
                var userValidado = this.ValidaDados(user);
                if (userValidado != null)
                {
                    var jaExiste = await _userRepository.GetByEmailAsync(user);
                    if (jaExiste != null)
                    {
                        return new { message = "Usuario já cadastrado no sistema" };
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    return new { massege = "Erro ao validar os dados" };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioModel> InserirNovoUsuario(InputUsuarioModel user)
        {
            try
            {
                var ret = await _userRepository.InsertAsync(new UsuarioModel
                {
                    Nome = user.Nome,
                    Email = user.Email,
                    Senha = user.Senha,
                });
                if (ret != null)
                {
                    await _userRepository.SaveAsync();
                    return ret;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;

        }

        public Task<string> AtualizarTabelas()
        {
            return _userRepository.AtualizarTabelas();
        }
    }
}
