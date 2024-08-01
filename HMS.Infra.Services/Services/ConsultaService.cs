using AutoMapper;
using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.UseCases.Consultas;
using HMS.Infra.Services.DTOs.HorarioDisponiveis;
using HMS.Infra.Services.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HMS.Infra.Services.Services
{
    public class ConsultaService : IConsultaService
    {         
        private readonly IConsultaGateway _consultaGateway;        
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public ConsultaService(IMapper mapper, IConsultaGateway consultaGateway, IEmailService emailService)
        {
            _mapper = mapper;
            _consultaGateway = consultaGateway;
            _emailService = emailService;
        }

        public ConsultaDto Agendar(AgendaConsultaDto agendaConsultaDto)
        {
            var consulta = _mapper.Map<Consulta>(agendaConsultaDto);

            var agendarConsultaUseCase = new AgendarConsultaUseCase(consulta, _consultaGateway);

            consulta = agendarConsultaUseCase.Agendar();

            consulta = _consultaGateway.Cadastrar(consulta);

            consulta = _consultaGateway.BuscarConsultaCompleta(consulta.Id);

            _emailService.EnviaEmailConsultaAgendada(consulta);

            return _mapper.Map<ConsultaDto>(consulta);
        }        
        
       
    }
}
