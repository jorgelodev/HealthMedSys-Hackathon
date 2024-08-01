using HMS.Domain.Entities;

namespace HMS.Domain.Interfaces.Repositories
{
    public interface IConsultaRepository : IRepositoryBase<Consulta>
    {
        Consulta BuscarContultaCompleta(int id);
    }
}
