using AutoMapper;
using Bogus;
using HMS.Domain.Entities;
using HMS.Domain.Excepctions;
using HMS.Domain.Interfaces.Gateways;
using HMS.Infra.Services.DTOs.HorarioDisponiveis;
using HMS.Infra.Services.DTOs.Usuarios;
using HMS.Infra.Services.Interfaces;
using HMS.Infra.Services.Services;
using Moq;

namespace HMS.Tests.Services
{
    public class ConsultaServiceTest
    {
        private readonly Mock<IConsultaGateway> _consultaGatewayMock;
        private readonly Mock<IPacienteGateway> _pacienteGatewayMock;
        private readonly Mock<IUsuarioGateway> _usuarioGatewayMock;
        private readonly Mock<IHorarioDisponivelGateway> _horarioDisponivelGatewayMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IEmailService> _emailServiceMock;
        private readonly ConsultaService _consultaService;
        private readonly Faker _faker;

        public ConsultaServiceTest()
        {
            _consultaGatewayMock = new Mock<IConsultaGateway>();
            _pacienteGatewayMock = new Mock<IPacienteGateway>();
            _usuarioGatewayMock = new Mock<IUsuarioGateway>();
            _horarioDisponivelGatewayMock = new Mock<IHorarioDisponivelGateway>();
            _mapperMock = new Mock<IMapper>();
            _emailServiceMock = new Mock<IEmailService>();

            _consultaService = new ConsultaService(
                _mapperMock.Object,
                _consultaGatewayMock.Object,
                _emailServiceMock.Object,
                _horarioDisponivelGatewayMock.Object,
                _pacienteGatewayMock.Object,
                _usuarioGatewayMock.Object
            );

            _faker = new Faker("pt_BR");
        }

        [Fact]
        public void Agendar_ShouldReturnConsultaDto_WhenValidData()
        {
            // Arrange
            var agendaConsultaDto = new Faker<AgendaConsultaDto>()
                .RuleFor(a => a.UsuarioAutenticadoDto, f => new UsuarioAutenticadoDto { Id = f.Random.Int(1, 1000) })
                .RuleFor(a => a.HorarioDisponivelId, f => f.Random.Int(1, 1000))
                .Generate();

            var usuario = new Faker<Usuario>()
                .RuleFor(u => u.Id, agendaConsultaDto.UsuarioAutenticadoDto.Id)
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .Generate();

            var paciente = new Faker<Paciente>()
                .RuleFor(p => p.Id, f => f.Random.Int(1, 1000))
                .RuleFor(p => p.UsuarioId, usuario.Id)
                .Generate();

            var consulta = new Faker<Consulta>()
                .RuleFor(c => c.PacienteId, paciente.Id)
                .RuleFor(c => c.HorarioDisponivelId, agendaConsultaDto.HorarioDisponivelId)
                .Generate();

            var horarioDisponivel = new Faker<HorarioDisponivel>()
                .RuleFor(h => h.Id, agendaConsultaDto.HorarioDisponivelId)
                .RuleFor(h => h.MedicoId, f => f.Random.Int(1, 1000))
                .Generate();

            var consultaDto = new Faker<ConsultaDto>()
                .RuleFor(c => c.Id, f => f.Random.Int(1, 1000))
                .Generate();

            _usuarioGatewayMock.Setup(g => g.ObterPorId(It.IsAny<int>())).Returns(usuario);
            _pacienteGatewayMock.Setup(g => g.ObterPorIdUsuario(It.IsAny<int>())).Returns(paciente);
            _mapperMock.Setup(m => m.Map<Consulta>(It.IsAny<AgendaConsultaDto>())).Returns(consulta);
            _horarioDisponivelGatewayMock.Setup(g => g.ObterPorId(It.IsAny<int>())).Returns(horarioDisponivel);
            _consultaGatewayMock.Setup(g => g.Cadastrar(It.IsAny<Consulta>())).Returns(consulta);
            _consultaGatewayMock.Setup(g => g.BuscarConsultaCompleta(It.IsAny<int>())).Returns(consulta);
            _mapperMock.Setup(m => m.Map<ConsultaDto>(It.IsAny<Consulta>())).Returns(consultaDto);

            // Act
            var result = _consultaService.Agendar(agendaConsultaDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(consultaDto.Id, result.Id);
            _emailServiceMock.Verify(e => e.EnviaEmailConsultaAgendada(It.IsAny<Consulta>()), Times.Once);
        }

        [Fact]
        public void Agendar_ShouldThrowException_WhenHorarioNotFound()
        {
            // Arrange
            var agendaConsultaDto = new Faker<AgendaConsultaDto>()
                .RuleFor(a => a.UsuarioAutenticadoDto, f => new UsuarioAutenticadoDto { Id = f.Random.Int(1, 1000) })
                .RuleFor(a => a.HorarioDisponivelId, f => f.Random.Int(1, 1000))
                .Generate();

            var usuario = new Faker<Usuario>()
                .RuleFor(u => u.Id, agendaConsultaDto.UsuarioAutenticadoDto.Id)
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .Generate();

            var paciente = new Faker<Paciente>()
                .RuleFor(p => p.Id, f => f.Random.Int(1, 1000))
                .RuleFor(p => p.UsuarioId, usuario.Id)
                .Generate();

            var consulta = new Faker<Consulta>()
                .RuleFor(c => c.PacienteId, paciente.Id)
                .RuleFor(c => c.HorarioDisponivelId, agendaConsultaDto.HorarioDisponivelId)
                .Generate();

            _usuarioGatewayMock.Setup(g => g.ObterPorId(It.IsAny<int>())).Returns(usuario);
            _pacienteGatewayMock.Setup(g => g.ObterPorIdUsuario(It.IsAny<int>())).Returns(paciente);
            _mapperMock.Setup(m => m.Map<Consulta>(It.IsAny<AgendaConsultaDto>())).Returns(consulta);
            _horarioDisponivelGatewayMock.Setup(g => g.ObterPorId(It.IsAny<int>())).Returns((HorarioDisponivel)null);

            // Act & Assert
            var exception = Assert.Throws<DomainValidationException>(() => _consultaService.Agendar(agendaConsultaDto));
            Assert.Equal("Horário não encontrado", exception.ValidationErrors.FirstOrDefault());
        }
    }
}
