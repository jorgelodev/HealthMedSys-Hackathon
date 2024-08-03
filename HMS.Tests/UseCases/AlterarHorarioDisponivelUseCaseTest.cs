using Bogus;
using HMS.Domain.Entities;
using HMS.Domain.Excepctions;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.UseCases.HorarioDisponiveis;
using Moq;

namespace HMS.Tests.UseCases
{
    public class AlterarHorarioDisponivelUseCaseTest
    {
        private readonly Faker<HorarioDisponivel> _horarioDisponivelFaker;
        private readonly Mock<IHorarioDisponivelGateway> _horarioDisponivelGatewayMock;

        public AlterarHorarioDisponivelUseCaseTest()
        {
            _horarioDisponivelFaker = new Faker<HorarioDisponivel>()
                .RuleFor(h => h.Id, f => f.Random.Int(1, 1000))
                .RuleFor(h => h.MedicoId, f => f.Random.Int(1, 1000))
                .RuleFor(h => h.DataHoraInicio, f => DateTime.Now.AddMinutes(10))
                .RuleFor(h => h.DataHoraFim, (f, h) => h.DataHoraInicio.AddMinutes(30));

            _horarioDisponivelGatewayMock = new Mock<IHorarioDisponivelGateway>();
        }

        [Fact]
        public void Alterar_DeveRetornarHorarioDisponivelQuandoValido()
        {
            // Arrange
            var horarioDisponivel = _horarioDisponivelFaker.Generate();
            var useCase = new AlterarHorarioDisponivelUseCase(horarioDisponivel, _horarioDisponivelGatewayMock.Object);

            // Act
            var result = useCase.Alterar();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(horarioDisponivel.Id, result.Id);
            Assert.Equal(horarioDisponivel.MedicoId, result.MedicoId);
            Assert.Equal(horarioDisponivel.DataHoraInicio, result.DataHoraInicio);
            Assert.Equal(horarioDisponivel.DataHoraFim, result.DataHoraFim);
        }

        [Fact]
        public void Alterar_DeveLancarExcecaoQuandoMedicoIdInvalido()
        {
            // Arrange
            var horarioDisponivel = _horarioDisponivelFaker.Generate();
            horarioDisponivel.MedicoId = 0; // MedicoId inválido
            var useCase = new AlterarHorarioDisponivelUseCase(horarioDisponivel, _horarioDisponivelGatewayMock.Object);

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => useCase.Alterar());
        }

        [Fact]
        public void Alterar_DeveLancarExcecaoQuandoDataHoraInicioInvalida()
        {
            // Arrange
            var horarioDisponivel = _horarioDisponivelFaker.Generate();
            horarioDisponivel.DataHoraInicio = default(DateTime); // DataHoraInicio inválida
            var useCase = new AlterarHorarioDisponivelUseCase(horarioDisponivel, _horarioDisponivelGatewayMock.Object);

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => useCase.Alterar());
        }

        [Fact]
        public void Alterar_DeveLancarExcecaoQuandoDataHoraFimInvalida()
        {
            // Arrange
            var horarioDisponivel = _horarioDisponivelFaker.Generate();
            horarioDisponivel.DataHoraFim = default(DateTime); // DataHoraFim inválida
            var useCase = new AlterarHorarioDisponivelUseCase(horarioDisponivel, _horarioDisponivelGatewayMock.Object);

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => useCase.Alterar());
        }

        [Fact]
        public void Alterar_DeveLancarExcecaoQuandoDatasInvalidas()
        {
            // Arrange
            var horarioDisponivel = _horarioDisponivelFaker.Generate();
            horarioDisponivel.DataHoraFim = horarioDisponivel.DataHoraInicio.AddMinutes(-1); // DataHoraFim anterior a DataHoraInicio
            var useCase = new AlterarHorarioDisponivelUseCase(horarioDisponivel, _horarioDisponivelGatewayMock.Object);

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => useCase.Alterar());
        }
    }
}
