using VetSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetSystem.Negocio.Cliente
{
    public interface IClienteNegocio
    {
        Task<ClienteModel> ObterUmCliente(string cpf);
        List<ClienteModel> ObterLista();
        Task IncluirCliente(ClienteModel clienteModel);
        //Task<List<Cliente>> ListaClientes();
        //Task<Cliente> ObterUmCliente(string cpf);
        Task AlterarCliente(ClienteModel clientesModel);
        Task ExcluirCliente(string cpf);
    }
}
