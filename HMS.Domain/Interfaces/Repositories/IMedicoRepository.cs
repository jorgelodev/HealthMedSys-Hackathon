using HMS.Domain.Entities;

namespace HMS.Domain.Interfaces.Repositories
{
    public interface IMedicoRepository : IRepositoryBase<Medico>
    {
        ICollection<Medico> Disponiveis();
    }
}
