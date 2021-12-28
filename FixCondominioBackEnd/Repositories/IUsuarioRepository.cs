using FixCondominioBackEnd.Models;
using FixCondominioBackEnd.Models.InputModels;
using Microsoft.EntityFrameworkCore;

namespace FixCondominioBackEnd.Repositories
{

    public interface IUsuarioRepository : IDisposable
    {
        Task<List<UsuarioModel>> GetAllAsync();
        Task<UsuarioModel> GetByIdAsync(int id);
        Task<UsuarioModel> InsertAsync(UsuarioModel user);
        Task<int> SaveAsync();
        Task<UsuarioModel> GetByUserAndPasswordAsync(InputLoginModel user);
        Task<UsuarioModel> GetByEmailAsync(InputUsuarioModel user);
        Task<string> AtualizarTabelas();
    }

    public class UsuarioRepository : IUsuarioRepository, IDisposable
    {
        private readonly Context _context;
        public UsuarioRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<UsuarioModel>> GetAllAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<UsuarioModel> GetByIdAsync(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }
        public async Task<UsuarioModel> GetByEmailAsync(InputUsuarioModel user)
        {
            return await _context.Usuario.Where(w => w.Email == user.Email).FirstOrDefaultAsync();
        }
        public async Task<UsuarioModel> GetByUserAndPasswordAsync(InputLoginModel user)
        {
            return await _context.Usuario.Where(w => w.Email == user.Email.ToLower() && w.Senha == user.Senha).FirstOrDefaultAsync();
        }

        public async Task<UsuarioModel> InsertAsync(UsuarioModel user)
        {
            await _context.Usuario.AddAsync(user);
            return user;
        }
        public async Task<string> AtualizarTabelas()
        {
            await _context.Database.MigrateAsync();
            return string.Empty;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }


        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }


    }

}
