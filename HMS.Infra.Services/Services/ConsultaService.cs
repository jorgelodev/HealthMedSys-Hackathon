using AutoMapper;
using HMS.Domain.Entities;
using HMS.Domain.Excepctions;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.UseCases.Consultas;
using HMS.Infra.Services.DTOs.HorarioDisponiveis;
using HMS.Infra.Services.Interfaces;

namespace HMS.Infra.Services.Services
{
    public class ConsultaService : IConsultaService
    {         
        private readonly IConsultaGateway _consultaGateway;
        private readonly IPacienteGateway _pacienteGateway;
        private readonly IUsuarioGateway _usuarioGateway;
        private readonly IHorarioDisponivelGateway _horarioDisponivelGateway;

        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public ConsultaService(IMapper mapper, IConsultaGateway consultaGateway, IEmailService emailService, IHorarioDisponivelGateway horarioDisponivelGateway, IPacienteGateway pacienteGateway, IUsuarioGateway usuarioGateway)
        {
            _mapper = mapper;
            _consultaGateway = consultaGateway;
            _emailService = emailService;
            _horarioDisponivelGateway = horarioDisponivelGateway;
            _pacienteGateway = pacienteGateway;
            _usuarioGateway = usuarioGateway;
        }

        public ConsultaDto Agendar(AgendaConsultaDto agendaConsultaDto)
        {
            var usuario = _usuarioGateway.ObterPorId(agendaConsultaDto.UsuarioAutenticadoDto.Id);
            var paciente = _pacienteGateway.ObterPorIdUsuario(usuario.Id);

            var consulta = _mapper.Map<Consulta>(agendaConsultaDto);
            consulta.PacienteId = paciente.Id;

            var horarioDisponivel = _horarioDisponivelGateway.ObterPorId(consulta.HorarioDisponivelId) ??
                throw new DomainValidationException("Horário não encontrado");

            var agendarConsultaUseCase = new AgendarConsultaUseCase(consulta, _consultaGateway);

            consulta = agendarConsultaUseCase.Agendar();

            try
            {
                consulta = _consultaGateway.Cadastrar(consulta);
            }
            catch (Exception ex)
            {
                throw new DomainValidationException("Não foi possível realizar o agendamento, por favor verifique os Horários Disponíveis e tente novamente.");
            }
            

            consulta = _consultaGateway.BuscarConsultaCompleta(consulta.Id);

            _emailService.EnviaEmailConsultaAgendada(consulta);

            return _mapper.Map<ConsultaDto>(consulta);
        }        
        
       
    }
}
