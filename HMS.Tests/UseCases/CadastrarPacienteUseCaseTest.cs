using Bogus;
using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.UseCases.Pacientes;
using Moq;

namespace HMS.Tests.UseCases
{
    public class CadastrarPacienteUseCaseTests
    {
        private readonly Faker<Paciente> _pacienteFaker;
        private readonly Mock<IPacienteGateway> _pacienteGatewayMock;

        public CadastrarPacienteUseCaseTests()
        {
            _pacienteFaker = new Faker<Paciente>()
                .RuleFor(p => p.Id, f => f.Random.Int(1, 1000))
                .RuleFor(p => p.Nome, f => f.Name.FullName())
                .RuleFor(p => p.CPF, f => "12345678901")
                .RuleFor(p => p.UsuarioId, f => f.Random.Int(1, 1000));

            _pacienteGatewayMock = new Mock<IPacienteGateway>();
        }

        [Fact]
        public void Cadastrar_DeveRetornarPacienteQuandoValido()
        {
            // Arrange
            var paciente = _pacienteFaker.Generate();
            var useCase = new CadastrarPacienteUseCase(paciente, _pacienteGatewayMock.Object);

            // Act
            var result = useCase.Cadastrar();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(paciente.Id, result.Id);
            Assert.Equal(paciente.Nome, result.Nome);
            Assert.Equal(paciente.CPF, result.CPF);
            Assert.Equal(paciente.UsuarioId, result.UsuarioId);
        }


    }
}
