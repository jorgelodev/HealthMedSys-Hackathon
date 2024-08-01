using HMS.Infra.Services.DTOs.HorarioDisponiveis;

namespace HMS.Infra.Services.Interfaces
{
    public interface IConsultaService
    {
        ConsultaDto Agendar(AgendaConsultaDto agendarConsultaDto);
            
    }
}
