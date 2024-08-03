using AutoMapper;
using HMS.Domain.Entities;
using HMS.Domain.Excepctions;
using HMS.Domain.Interfaces.Gateways;
using HMS.Infra.Services.DTOs.HorarioDisponiveis;
using HMS.Infra.Services.Interfaces;
using HMS.Infra.Services.Services;
using Moq;

namespace HMS.Tests.Services
{
    public class ConsultaServiceTest
    {
        private readonly Mock<IConsultaGateway> _consultaGatewayMock;
        private readonly Mock<IHorarioDisponivelGateway> _horarioDisponivelGatewayMock;
        private readonly Mock<IEmailService> _emailServiceMock;
        private readonly IMapper _mapper;
        private readonly IConsultaService _consultaService;

        public ConsultaServiceTest()
        {
            _consultaGatewayMock = new Mock<IConsultaGateway>();
            _horarioDisponivelGatewayMock = new Mock<IHorarioDisponivelGateway>();
            _emailServiceMock = new Mock<IEmailService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AgendaConsultaDto, Consulta>();
                cfg.CreateMap<Consulta, ConsultaDto>();
            });
            _mapper = config.CreateMapper();

            _consultaService = new ConsultaService(_mapper, _consultaGatewayMock.Object, _emailServiceMock.Object, _horarioDisponivelGatewayMock.Object);
        }

        [Fact]
        public void Agendar_DeveRetornarConsultaDtoQuandoAgendamentoForBemSucedido()
        {
            // Arrange
            var agendaConsultaDto = new AgendaConsultaDto
            {
                HorarioDisponivelId = 1,
                PacienteId = 1
            };

            var horarioDisponivel = new HorarioDisponivel { Id = 1 };
            var consulta = new Consulta { Id = 1, HorarioDisponivelId = 1, PacienteId = 1 };

            _horarioDisponivelGatewayMock.Setup(h => h.ObterPorId(1)).Returns(horarioDisponivel);
            _consultaGatewayMock.Setup(c => c.Cadastrar(It.IsAny<Consulta>())).Returns(consulta);
            _consultaGatewayMock.Setup(c => c.BuscarConsultaCompleta(1)).Returns(consulta);

            // Act
            var result = _consultaService.Agendar(agendaConsultaDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(consulta.Id, result.Id);
        }

        [Fact]
        public void Agendar_DeveLancarExcecaoQuandoHorarioNaoEncontrado()
        {
            // Arrange
            var agendaConsultaDto = new AgendaConsultaDto
            {
                HorarioDisponivelId = 1,
                PacienteId = 1
            };

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => _consultaService.Agendar(agendaConsultaDto));
        }

        [Fact]
        public void Agendar_DeveLancarExcecaoQuandoErroAoCadastrarConsulta()
        {
            // Arrange
            var agendaConsultaDto = new AgendaConsultaDto
            {
                HorarioDisponivelId = 1,
                PacienteId = 1
            };

            var horarioDisponivel = new HorarioDisponivel { Id = 1 };
            var consulta = new Consulta { Id = 1, HorarioDisponivelId = 1, PacienteId = 1 };

            _horarioDisponivelGatewayMock.Setup(h => h.ObterPorId(1)).Returns(horarioDisponivel);
            _consultaGatewayMock.Setup(c => c.Cadastrar(It.IsAny<Consulta>())).Throws(new Exception());

            // Act & Assert
            var exception = Assert.Throws<DomainValidationException>(() => _consultaService.Agendar(agendaConsultaDto));
            Assert.Equal("Não foi possível realizar o agendamento, por favor verifique os Horários Disponíveis e tente novamente.", exception.ValidationErrors[0]);
        }
    }
}
