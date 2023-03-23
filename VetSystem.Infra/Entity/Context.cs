using VetSystem.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace VetSystem.Entity
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<EspecieModel> Especies { get; set; }
        public DbSet<MedicamentoModel> Medicamentos { get; set; }
        public DbSet<ProcedimentoModel> Procedimentos { get; set; }

    }
}
