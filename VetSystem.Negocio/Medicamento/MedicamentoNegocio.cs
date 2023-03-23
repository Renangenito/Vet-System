using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetSystem.Entity;
using VetSystem.Models.Models;

namespace VetSystem.Negocio.Medicamento
{
    public class MedicamentoNegocio : IMedicamentoNegocio
    {
        private readonly Context _context;

        public MedicamentoNegocio(Context context)
        {
            _context = context;
        }

        public async Task<MedicamentoModel> ObterUmMedicamento(int id)
        {
            return await _context.Medicamentos.SingleAsync(x => x.Id.Equals(id));
        }
        public List<MedicamentoModel> ObterLista()
        {
            return _context.Medicamentos.ToList();
        }
        public async Task IncluirMedicamento(MedicamentoModel medicamentoModel)
        {
            _context.Medicamentos.Add(medicamentoModel);
            await _context.SaveChangesAsync();

        }
        public async Task AlterarMedicamento(MedicamentoModel medicamentoModel)
        {
            _context.Medicamentos.Update(medicamentoModel);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirMedicamento(int id)
        {
            var idRetorno = await _context.Medicamentos.SingleAsync(x => x.Id.Equals(id));
            _context.Medicamentos.Remove(idRetorno);
            await _context.SaveChangesAsync();
        }

    }
}
