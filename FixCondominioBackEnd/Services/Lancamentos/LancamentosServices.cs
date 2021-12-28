using FixCondominioBackEnd.Models;
using FixCondominioBackEnd.Models.InputModels;
using FixCondominioBackEnd.Models.ViewModels;
using FixCondominioBackEnd.Repositories;

namespace FixCondominioBackEnd.Services.Lancamentos
{
    public interface ILancamentosServices
    {
        Task<List<LancamentosModel>> GetAll();
        Task<ViewLancamentosModel> GetById(int id);
        Task<ViewLancamentosModel> Create(InputLancamentoModel lancamentoModel);
        Task<ViewLancamentosModel> Update(InputLancamentoModel lancamentoModel);
        Task<ViewLancamentosModel> Delete(InputLancamentoModel lancamentoModel);
    }
    public class LancamentosServices : ILancamentosServices
    {
        private readonly ILancamentoRepository _lancamentosRepository;
        public LancamentosServices(ILancamentoRepository lancamentoRepository)
        {
            _lancamentosRepository = lancamentoRepository;
        }
        public Task<ViewLancamentosModel> Create(InputLancamentoModel lancamentoModel)
        {
            throw new NotImplementedException();
        }

        public Task<ViewLancamentosModel> Delete(InputLancamentoModel lancamentoModel)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LancamentosModel>> GetAll()
        {
            return await _lancamentosRepository.GetAllAsync();
        }

        public Task<ViewLancamentosModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ViewLancamentosModel> Update(InputLancamentoModel lancamentoModel)
        {
            throw new NotImplementedException();
        }
    }
}
