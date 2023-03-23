using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetSystem.Models.Models;

namespace VetSystem.Negocio.Medicamento
{
    public interface IMedicamentoNegocio
    {
        Task<MedicamentoModel> ObterUmMedicamento(int id);
        List<MedicamentoModel> ObterLista();
        Task IncluirMedicamento(MedicamentoModel medicamentoModel);
        Task AlterarMedicamento(MedicamentoModel medicamentoModel);
        Task ExcluirMedicamento(int id);
    }
}
