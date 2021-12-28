using FixCondominioBackEnd.Models;
using FixCondominioBackEnd.Models.InputModels;
using FixCondominioBackEnd.Models.ViewModels;
using FixCondominioBackEnd.Services.Lancamentos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixCondominioBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LancamentosController : ControllerBase
    {        
        private readonly ILancamentosServices _lancamentoService;

        public LancamentosController(ILancamentosServices lancamentosServices)
        {
            _lancamentoService = lancamentosServices;
        }

        [HttpGet]
        [Route("buscartodos")]
        [AllowAnonymous]
        public async Task<IEnumerable<ViewLancamentosModel>> GetAll() =>
             await _lancamentoService.GetAll();

        [HttpPost]
        [Route("criar")]
        [AllowAnonymous]
        public async Task<ViewLancamentosModel> Create(InputLancamentoModel inputLancamentoModel)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            var ret = await _lancamentoService.Create(inputLancamentoModel);

            return ret;
        }
    }
}
