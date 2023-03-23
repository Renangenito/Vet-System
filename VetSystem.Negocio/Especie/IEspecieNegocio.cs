using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetSystem.Models.Models;

namespace VetSystem.Negocio.Especie
{
    public interface IEspecieNegocio
    {
        Task<EspecieModel> ObterUmaEspecie(int id);
        List<EspecieModel> ObterLista();
        Task IncluirEspecie(EspecieModel especieModel);
        Task AlterarEspecie(EspecieModel especieModel);
        Task ExcluirEspecie(int id);


    }
}
