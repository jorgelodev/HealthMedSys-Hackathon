using Bogus;
using HMS.Domain.Entities;
using HMS.Domain.Excepctions;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.UseCases.HorarioDisponiveis;
using Moq;

namespace HMS.Tests.UseCases
{
    public class CadastrarHorarioDisponivelUseCaseTest
    {
        private readonly Faker<HorarioDisponivel> _horarioDisponivelFaker;
        private readonly Mock<IHorarioDisponivelGateway> _horarioDisponivelGatewayMock;

        public CadastrarHorarioDisponivelUseCaseTest()
        {
            _horarioDisponivelFaker = new Faker<HorarioDisponivel>()
                .RuleFor(h => h.Id, f => f.Random.Int(1, 1000))
                .RuleFor(h => h.MedicoId, f => f.Random.Int(1, 1000))
                .RuleFor(h => h.DataHoraInicio, f => DateTime.Now.AddMinutes(10))
                .RuleFor(h => h.DataHoraFim, (f, h) => DateTime.Now.AddMinutes(40));

            _horarioDisponivelGatewayMock = new Mock<IHorarioDisponivelGateway>();
        }

        [Fact]
        public void Cadastrar_DeveRetornarHorarioDisponivelQuandoValido()
        {
            // Arrange
            var horarioDisponivel = _horarioDisponivelFaker.Generate();

            _horarioDisponivelGatewayMock.Setup(g => g.HorarioEstaDesocupado(It.IsAny<HorarioDisponivel>())).Returns(true);

            var useCase = new CadastrarHorarioDisponivelUseCase(horarioDisponivel, _horarioDisponivelGatewayMock.Object);

            // Act
            var result = useCase.Cadastrar();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(horarioDisponivel.Id, result.Id);
            Assert.Equal(horarioDisponivel.MedicoId, result.MedicoId);
            Assert.Equal(horarioDisponivel.DataHoraInicio, result.DataHoraInicio);
            Assert.Equal(horarioDisponivel.DataHoraFim, result.DataHoraFim);
        }

        [Fact]
        public void Cadastrar_DeveLancarExcecaoQuandoHorarioOcupado()
        {
            // Arrange
            var horarioDisponivel = _horarioDisponivelFaker.Generate();
            _horarioDisponivelGatewayMock.Setup(g => g.HorarioEstaDesocupado(It.IsAny<HorarioDisponivel>())).Returns(false);
            var useCase = new CadastrarHorarioDisponivelUseCase(horarioDisponivel, _horarioDisponivelGatewayMock.Object);

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => useCase.Cadastrar());
        }

        [Fact]
        public void Cadastrar_DeveLancarExcecaoQuandoMedicoIdInvalido()
        {
            // Arrange
            var horarioDisponivel = _horarioDisponivelFaker.Generate();
            horarioDisponivel.MedicoId = 0; // MedicoId inválido
            var useCase = new CadastrarHorarioDisponivelUseCase(horarioDisponivel, _horarioDisponivelGatewayMock.Object);

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => useCase.Cadastrar());
        }

        [Fact]
        public void Cadastrar_DeveLancarExcecaoQuandoDataHoraInicioInvalida()
        {
            // Arrange
            var horarioDisponivel = _horarioDisponivelFaker.Generate();
            horarioDisponivel.DataHoraInicio = default(DateTime); // DataHoraInicio inválida
            var useCase = new CadastrarHorarioDisponivelUseCase(horarioDisponivel, _horarioDisponivelGatewayMock.Object);

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => useCase.Cadastrar());
        }

        [Fact]
        public void Cadastrar_DeveLancarExcecaoQuandoDataHoraFimInvalida()
        {
            // Arrange
            var horarioDisponivel = _horarioDisponivelFaker.Generate();
            horarioDisponivel.DataHoraFim = default(DateTime); // DataHoraFim inválida
            var useCase = new CadastrarHorarioDisponivelUseCase(horarioDisponivel, _horarioDisponivelGatewayMock.Object);

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => useCase.Cadastrar());
        }

        [Fact]
        public void Cadastrar_DeveLancarExcecaoQuandoDatasInvalidas()
        {
            // Arrange
            var horarioDisponivel = _horarioDisponivelFaker.Generate();
            horarioDisponivel.DataHoraFim = horarioDisponivel.DataHoraInicio.AddHours(-1); // DataHoraFim anterior a DataHoraInicio
            var useCase = new CadastrarHorarioDisponivelUseCase(horarioDisponivel, _horarioDisponivelGatewayMock.Object);

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => useCase.Cadastrar());
        }
    }
}
