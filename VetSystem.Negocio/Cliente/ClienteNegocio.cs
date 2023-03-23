using Microsoft.EntityFrameworkCore;
using VetSystem.Entity;
using VetSystem.Models.Models;
using VetSystem.Negocio.Cliente;


namespace VetSystem.Negocio.Cliente
{
    public class ClienteNegocio : IClienteNegocio
    {
        private readonly Context _context;

        public ClienteNegocio(Context context)
        {
            _context = context;
        }

        public async Task<ClienteModel> ObterUmCliente(string cpf)
        {
            return await _context.Clientes.SingleAsync(x => x.Cpf.Equals(cpf));
        }
        public List<ClienteModel> ObterLista()
        {
            return _context.Clientes.ToList();
        }
        public async Task IncluirCliente(ClienteModel clientesModel)
        {
            _context.Clientes.Add(clientesModel);
            await _context.SaveChangesAsync();

        }
        public async Task AlterarCliente(ClienteModel clientesModel)
        {
            _context.Clientes.Update(clientesModel);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirCliente(string cpf)
        {
            var cpfRetorno = await _context.Clientes.SingleAsync(x => x.Cpf.Equals(cpf));
            _context.Clientes.Remove(cpfRetorno);
            await _context.SaveChangesAsync();
        }
    }
}
