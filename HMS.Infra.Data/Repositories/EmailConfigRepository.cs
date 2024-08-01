using Azure.Core;
using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Repositories;
using HMS.Infra.Data.Context;

namespace HMS.Infra.Data.Repositories
{
    public class EmailConfigRepository : RepositoryBase<EmailConfig>, IEmailConfigRepository
    {
        public EmailConfigRepository(ApplicationDbContext context) : base(context)
        {
        }

        public EmailConfig Buscar()
        {
            return this._dbSet.ToList().FirstOrDefault();
        }
    }
}
