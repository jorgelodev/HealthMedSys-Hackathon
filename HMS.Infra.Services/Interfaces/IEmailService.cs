using HMS.Domain.Entities;

namespace HMS.Infra.Services.Interfaces
{
    public interface IEmailService
    {
        Task EnviaEmailConsultaAgendada(Consulta consulta);
        
    }
}
