using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetSystem.Entity;
using VetSystem.Models.Models;

namespace VetSystem.Negocio.Especie
{
    public class EspecieNegocio : IEspecieNegocio
    {
        private readonly Context _context;

        public EspecieNegocio(Context context)
        {
            _context = context;
        }

        public async Task<EspecieModel> ObterUmaEspecie(int id)
        {
            return await _context.Especies.SingleAsync(x => x.Id.Equals(id));
        }

        public void Incluir(EspecieModel especieModel)
        {
            throw new NotImplementedException();
        }

        public List<EspecieModel> ObterLista()
        {
            return _context.Especies.ToList();
        }
        public async Task IncluirEspecie(EspecieModel especieModel)
        {
            _context.Especies.Add(especieModel);
            await _context.SaveChangesAsync();

        }
        public async Task AlterarEspecie(EspecieModel especieModel)
        {
            _context.Especies.Update(especieModel);
            await _context.SaveChangesAsync();
        }
        public async Task ExcluirEspecie(int id)
        {
            var idRetorno = await _context.Especies.SingleAsync(x => x.Id.Equals(id));
            _context.Especies.Remove(idRetorno);
            await _context.SaveChangesAsync();
        }
    }
}

