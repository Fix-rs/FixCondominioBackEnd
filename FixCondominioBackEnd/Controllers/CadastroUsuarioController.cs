using FixCondominioBackEnd.Models.InputModels;
using FixCondominioBackEnd.Models.ViewModels;
using FixCondominioBackEnd.Services.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixCondominioBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroUsuarioController : ControllerBase
    {
        private readonly IContaUsuarioService _contaService;

        public CadastroUsuarioController(IContaUsuarioService contaService)
        {
            _contaService = contaService;
        }


        [HttpPost]
        [Route("criar")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] InputUsuarioModel model)
        {
            var user = _contaService.ValidaDados(model);
            var jaExite = await _contaService.VerificaSeJaExiste(model);

            if (jaExite != null)
            {
                return BadRequest(jaExite);
            };

            if (!ModelState.IsValid || user == null)
            {
                return NotFound(new { massege = "Modelo enviado esta incorreto" });
            }

            try
            {

                return Ok((ViewUsuarioModel)await _contaService.InserirNovoUsuario(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

    }
}
