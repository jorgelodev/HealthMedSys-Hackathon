using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Repositories;
using HMS.Infra.Data.Context;

namespace HMS.Infra.Data.Repositories
{
    public class HorarioDisponivelRepository : RepositoryBase<HorarioDisponivel>, IHorarioDisponivelRepository
    {
        public HorarioDisponivelRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
