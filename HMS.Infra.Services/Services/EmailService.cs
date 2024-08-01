using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Infra.Services.Interfaces;

namespace HMS.Infra.Services.Services
{
    public class EmailService : EmailSenderService, IEmailService
    {
        public EmailService(IEmailConfigGateway emailConfigGateway) : base(emailConfigGateway)
        {
        }

        public async Task EnviaEmailConsultaAgendada(Consulta consulta)
        {
            var titulo = "Health&Med - Nova consulta agendada";
            var corpo = $"Olá, Dr.{consulta.HorarioDisponivel.Medico.Nome}!" + Environment.NewLine + Environment.NewLine;
            corpo += $"Você tem uma nova consulta marcada!" + Environment.NewLine;
            corpo += $"Paciente:  {consulta.Paciente.Nome}." + Environment.NewLine;
            corpo += $"Data e horário:  {consulta.HorarioDisponivel.DataHoraInicio.ToString("dd/MM")} às {consulta.HorarioDisponivel.DataHoraInicio.ToString("HH:mm")}.";

            await EnviaEmailAsync(consulta.HorarioDisponivel.Medico.Usuario.Email, titulo, corpo);
        }

        
    }
}
