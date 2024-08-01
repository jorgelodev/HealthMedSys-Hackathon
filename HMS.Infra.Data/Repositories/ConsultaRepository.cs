using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Repositories;
using HMS.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HMS.Infra.Data.Repositories
{
    public class ConsultaRepository : RepositoryBase<Consulta>, IConsultaRepository
    {
        public ConsultaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Consulta BuscarContultaCompleta(int id)
        {
            return this._dbSet.
                Where(c => c.Id == id).
                Include(c => c.Paciente).
                Include(c => c.HorarioDisponivel).
                ThenInclude(h => h.Medico).
                ThenInclude(m => m.Usuario)
                .FirstOrDefault();

        }
    }
}
