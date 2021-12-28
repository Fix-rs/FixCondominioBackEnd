using FixCondominioBackEnd.Models;
using FixCondominioBackEnd.Models.InputModels;
using FixCondominioBackEnd.Models.ViewModels;
using FixCondominioBackEnd.Repositories;

namespace FixCondominioBackEnd.Services.Lancamentos
{
    public interface ILancamentosServices
    {
        Task<IEnumerable<ViewLancamentosModel>> GetAll();
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
        public async Task<ViewLancamentosModel> Create(InputLancamentoModel inputlancamentoModel)
        {
            var lancamentoModel = new LancamentosModel()
            {
                Descricao = inputlancamentoModel.Descricao,
                Valor = inputlancamentoModel.Valor,
                Lancamento = inputlancamentoModel.Lancamento
            };
            return await _lancamentosRepository.InsertAsync(lancamentoModel);
        }

        public Task<ViewLancamentosModel> Delete(InputLancamentoModel lancamentoModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ViewLancamentosModel>> GetAll()
        {
            var ret = await _lancamentosRepository.GetAllAsync();

            return ret.Select(r => (ViewLancamentosModel)r).ToList();
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
