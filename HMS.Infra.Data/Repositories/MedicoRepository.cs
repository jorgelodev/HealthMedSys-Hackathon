using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Repositories;
using HMS.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HMS.Infra.Data.Repositories
{
    public class MedicoRepository : RepositoryBase<Medico>, IMedicoRepository
    {
        public MedicoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ICollection<Medico> Disponiveis()
        {
            var lista = this._dbSet
                .Include(m => m.HorariosDisponiveis)
                .Where(m => m.HorariosDisponiveis.Any(h => h.Consulta == null))
                .ToList();

            
            return lista;
        }       
    }
}
