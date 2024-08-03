using Bogus;
using HMS.Domain.Entities;
using HMS.Domain.Excepctions;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.UseCases.Consultas;
using Moq;

namespace HMS.Tests.UseCases
{
    public class AgendarConsultaUseCaseTest
    {
        private readonly Faker<Consulta> _consultaFaker;
        private readonly Faker<HorarioDisponivel> _horarioDisponivelFaker;
        private readonly Mock<IConsultaGateway> _consultaGatewayMock;

        public AgendarConsultaUseCaseTest()
        {
            _consultaFaker = new Faker<Consulta>()
                .RuleFor(c => c.Id, f => f.Random.Int(1, 100))
                .RuleFor(c => c.PacienteId, f => f.Random.Int(1, 100))
                .RuleFor(c => c.HorarioDisponivelId, f => f.Random.Int(1, 100));

            _horarioDisponivelFaker = new Faker<HorarioDisponivel>()
                    .RuleFor(h => h.Id, f => f.Random.Int(1, 100))
                    .RuleFor(h => h.DataHoraInicio, f => DateTime.Now.AddMinutes(10))
                    .RuleFor(h => h.DataHoraFim, f => DateTime.Now.AddMinutes(40));

            _consultaGatewayMock = new Mock<IConsultaGateway>();

        }

        [Fact]
        public void Agendar_DeveRetornarConsultaQuandoValido()
        {
            // Arrange
            var consulta = _consultaFaker.Generate();
            var horaDisponivel = _horarioDisponivelFaker.Generate();

            _consultaGatewayMock.Setup(g => g.Cadastrar(It.IsAny<Consulta>())).Returns(consulta);

            var useCase = new AgendarConsultaUseCase(consulta, _consultaGatewayMock.Object);

            // Act
            var result = useCase.Agendar();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(consulta.Id, result.Id);
            Assert.Equal(consulta.PacienteId, result.PacienteId);
            Assert.Equal(consulta.HorarioDisponivelId, result.HorarioDisponivelId);            
        }

        [Fact]
        public void Agendar_DeveLancarExcecaoQuandoConsultaSemPacienteId()
        {
            // Arrange
            var consulta = _consultaFaker.Generate();
            consulta.PacienteId = 0; 

            var useCase = new AgendarConsultaUseCase(consulta, _consultaGatewayMock.Object);

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => useCase.Agendar());
        }

       
    }
}