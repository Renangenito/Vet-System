using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetSystem.Models.Models;
using VetSystem.Negocio.Cliente;

namespace VetSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteNegocio _cliente;

        public ClienteController(IClienteNegocio cliente)
        {
            _cliente = cliente;
        }

        [HttpGet("ObterDadosCliente")]
        public async Task<ClienteModel> Get([FromQuery] string cpf)
        {

            return await _cliente.ObterUmCliente(cpf);
        }
        [HttpGet("ObterTodosClientes")]
        public async Task<List<ClienteModel>> Get()
        {
            return _cliente.ObterLista();

        }
        [HttpPost()]
        public async Task Post([FromBody] ClienteModel clienteModel)
        {
            clienteModel.DataInclusao = DateTime.Now;
            clienteModel.DataAlteracao = null;
             await _cliente.IncluirCliente(clienteModel);
        }

        [HttpPut()]
        public async Task Put([FromBody] ClienteModel clienteModel)
        {
            clienteModel.DataAlteracao = DateTime.Now;
            await _cliente.AlterarCliente(clienteModel);
        }
        //[HttpDelete()]
        //public async Task ExcluirCliente(string valor)
        //{
        //    await _cliente.ExcluirCliente(valor);
        //}
    }
}
