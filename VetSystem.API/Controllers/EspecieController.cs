using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VetSystem.Models.Models;
using VetSystem.Negocio.Especie;

namespace VetSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EspecieController : Controller
    {
        private readonly IEspecieNegocio _especie;

        public EspecieController(IEspecieNegocio especie)
        {
            _especie = especie;
        }

        [HttpGet("ObterDadosEspecie")]
        public async Task<EspecieModel> ObterDadosEspecie([FromQuery] int id)
        {

            return await _especie.ObterUmaEspecie(id);
        }

        [HttpGet("ObterTodasEspecies")]
        public async Task<List<EspecieModel>> Get()
        {
            return _especie.ObterLista();

        }

        [HttpPost()]
        public async Task Post([FromBody] EspecieModel especieModel)
        {
            especieModel.DataInclusao = DateTime.Now;
            especieModel.DataAlteracao = null;
            await _especie.IncluirEspecie(especieModel);
        }

        [HttpPut()]
        public async Task Put([FromBody] EspecieModel especieModel)
        {
            especieModel.DataAlteracao = DateTime.Now;
            await _especie.AlterarEspecie(especieModel);
        }
        [HttpDelete("ExcluirEspecie")]
        public async Task ExcluirEspecie(int id)
        {
            await _especie.ExcluirEspecie(id);
        }
    }
}
