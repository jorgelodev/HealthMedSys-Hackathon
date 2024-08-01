using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.Interfaces.Repositories;

namespace HMS.Infra.Gateways.Gateways
{
    public class EmailConfigGateway : IEmailConfigGateway
    {
        private readonly IEmailConfigRepository _emailConfigRepository;

        public EmailConfigGateway(IEmailConfigRepository emailConfigRepository)
        {
            _emailConfigRepository = emailConfigRepository;
        }

        public EmailConfig Buscar()
        {
            return _emailConfigRepository.Buscar();
        }
    }
}
