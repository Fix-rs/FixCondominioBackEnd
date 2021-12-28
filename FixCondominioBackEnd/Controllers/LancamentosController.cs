using FixCondominioBackEnd.Models;
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

        [HttpPost]
        [Route("buscartodos")]
        [AllowAnonymous]
        public async Task<List<LancamentosModel>> GetAll()
        {
            var ret = await _lancamentoService.GetAll();

            return ret;
        }
    }
}
