using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Repositories;
using HMS.Infra.Data.Context;

namespace HMS.Infra.Data.Repositories
{
    public class PacienteRepository : RepositoryBase<Paciente>, IPacienteRepository
    {
        public PacienteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
