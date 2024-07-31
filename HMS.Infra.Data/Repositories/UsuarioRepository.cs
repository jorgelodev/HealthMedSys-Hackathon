using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Repositories;
using HMS.Infra.Data.Context;

namespace HMS.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
