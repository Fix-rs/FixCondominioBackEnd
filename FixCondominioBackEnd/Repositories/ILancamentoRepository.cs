using FixCondominioBackEnd.Models;
using FixCondominioBackEnd.Models.InputModels;
using FixCondominioBackEnd.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FixCondominioBackEnd.Repositories
{

    public interface ILancamentoRepository : IDisposable
    {
        Task<IEnumerable<LancamentosModel>> GetAllAsync();
        Task<LancamentosModel> GetByIdAsync(int id);
        Task<LancamentosModel> InsertAsync(LancamentosModel user);
        Task<int> SaveAsync();
    }

    public class LancamentoRepository : ILancamentoRepository, IDisposable
    {
        private readonly Context _context;
        public LancamentoRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LancamentosModel>> GetAllAsync()
        {
            return await _context.Lancamentos.ToListAsync();
        }

        public async Task<LancamentosModel> GetByIdAsync(int id)
        {
            return await _context.Lancamentos.FindAsync(id);
        }
       
        public async Task<LancamentosModel> InsertAsync(LancamentosModel lancamentoModel)
        {
            await _context.Lancamentos.AddAsync(lancamentoModel);
            await _context.SaveChangesAsync();
            return lancamentoModel;
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
