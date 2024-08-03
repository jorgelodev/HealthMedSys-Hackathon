using Bogus;
using HMS.Domain.Entities;
using HMS.Domain.Excepctions;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.UseCases.Medicos;
using Moq;

namespace HMS.Tests.UseCases
{
    public class CadastrarMedicoUseCaseTest
    {
        private readonly Faker<Medico> _medicoFaker;
        private readonly Mock<IMedicoGateway> _medicoGatewayMock;

        public CadastrarMedicoUseCaseTest()
        {
            _medicoFaker = new Faker<Medico>()
                .RuleFor(m => m.Id, f => f.Random.Int(1, 1000))
                .RuleFor(m => m.Nome, f => f.Name.FullName())
                .RuleFor(m => m.CPF, f => "12345678901")
                .RuleFor(m => m.NumeroCRM, f => f.Random.AlphaNumeric(13).ToUpper())
                .RuleFor(m => m.UsuarioId, f => f.Random.Int(1, 1000));

            _medicoGatewayMock = new Mock<IMedicoGateway>();
        }

        [Fact]
        public void Cadastrar_DeveRetornarMedicoQuandoValido()
        {
            // Arrange
            var medico = _medicoFaker.Generate();
            var useCase = new CadastrarMedicoUseCase(medico, _medicoGatewayMock.Object);

            // Act
            var result = useCase.Cadastrar();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(medico.Id, result.Id);
            Assert.Equal(medico.Nome, result.Nome);
            Assert.Equal(medico.CPF, result.CPF);
            Assert.Equal(medico.NumeroCRM, result.NumeroCRM);
            Assert.Equal(medico.UsuarioId, result.UsuarioId);
        }

        [Fact]
        public void Cadastrar_DeveLancarExcecaoQuandoNumeroCRMInvalido()
        {
            // Arrange
            var medico = _medicoFaker.Generate();
            medico.NumeroCRM = "";
            var useCase = new CadastrarMedicoUseCase(medico, _medicoGatewayMock.Object);

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => useCase.Cadastrar());
        }

        [Fact]
        public void Cadastrar_DeveLancarExcecaoQuandoNumeroCRMMalFormado()
        {
            // Arrange
            var medico = _medicoFaker.Generate();
            medico.NumeroCRM = "1234";
            var useCase = new CadastrarMedicoUseCase(medico, _medicoGatewayMock.Object);

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => useCase.Cadastrar());
        }
    }
}
