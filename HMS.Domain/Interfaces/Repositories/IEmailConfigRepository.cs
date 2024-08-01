using HMS.Domain.Entities;

namespace HMS.Domain.Interfaces.Repositories
{
    public interface IEmailConfigRepository : IRepositoryBase<EmailConfig>
    {
        EmailConfig Buscar();
    }
}
