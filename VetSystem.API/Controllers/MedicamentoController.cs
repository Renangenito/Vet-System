using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetSystem.Models.Models;
using VetSystem.Negocio.Medicamento;

namespace VetSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicamentoController : ControllerBase
    {
        private readonly IMedicamentoNegocio _medicamento;

        public MedicamentoController(IMedicamentoNegocio medicamento)
        {
            _medicamento = medicamento;
        }

        [HttpGet("ObterDadosMedicamento")]
        public async Task<MedicamentoModel> Get([FromQuery] int id)
        {

            return await _medicamento.ObterUmMedicamento(id);
        }

        [HttpGet("ObterTodosMedicamentos")]
        public async Task<List<MedicamentoModel>> Get()
        {
            return _medicamento.ObterLista();

        }
        [HttpPost()]
        public async Task Post([FromBody] MedicamentoModel medicamentoModel)
        {
            medicamentoModel.DataInclusao = DateTime.Now;
            medicamentoModel.DataAlteracao = null;
            await _medicamento.IncluirMedicamento(medicamentoModel);
        }

        [HttpPut()]
        public async Task Put([FromBody] MedicamentoModel medicamentoModel)
        {
            medicamentoModel.DataAlteracao = DateTime.Now;
            await _medicamento.AlterarMedicamento(medicamentoModel);
        }
        [HttpDelete()]
        public async Task Delete(int id)
        {
            await _medicamento.ExcluirMedicamento(id);
        }
    }
}
