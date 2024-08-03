using Bogus;
using HMS.Domain.Entities;
using HMS.Domain.Excepctions;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.UseCases.Usuarios;
using Moq;


namespace HMS.Tests.UseCases
{
    public class CadastrarUsuarioUseCaseTests
    {
        private readonly Faker<Usuario> _usuarioFaker;
        private readonly Mock<IUsuarioGateway> _usuarioGatewayMock;

        public CadastrarUsuarioUseCaseTests()
        {
            _usuarioFaker = new Faker<Usuario>()
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Senha, f => f.Internet.Password())
                .RuleFor(u => u.Tipo, f => Usuario.TipoUsuario.MEDICO);

            _usuarioGatewayMock = new Mock<IUsuarioGateway>();
        }

        [Fact]
        public void Cadastrar_DeveRetornarUsuarioPacienteQuandoValido()
        {
            // Arrange
            var usuario = _usuarioFaker.Generate();
            usuario.Tipo = Usuario.TipoUsuario.PACIENTE;

            _usuarioGatewayMock.Setup(g => g.EmailJaUtilizado(usuario)).Returns(false);

            var useCase = new CadastrarUsuarioUseCase(usuario, _usuarioGatewayMock.Object);

            // Act
            var result = useCase.Cadastrar();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(usuario.Email, result.Email);
            Assert.Equal(usuario.Senha, result.Senha);
            Assert.Equal(usuario.Tipo, result.Tipo);
        }

        [Fact]
        public void Cadastrar_DeveRetornarUsuarioMedicoQuandoValido()
        {
            // Arrange
            var usuario = _usuarioFaker.Generate();
            usuario.Tipo = Usuario.TipoUsuario.MEDICO;            

            _usuarioGatewayMock.Setup(g => g.EmailJaUtilizado(usuario)).Returns(false);

            var useCase = new CadastrarUsuarioUseCase(usuario, _usuarioGatewayMock.Object);

            // Act
            var result = useCase.Cadastrar();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(usuario.Email, "");
            Assert.Equal(usuario.Senha, result.Senha);
            Assert.Equal(usuario.Tipo, result.Tipo);
        }

        [Fact]
        public void Cadastrar_DeveLancarExcecaoQuandoEmailJaExistente()
        {
            // Arrange
            var usuario = _usuarioFaker.Generate();
            _usuarioGatewayMock.Setup(g => g.EmailJaUtilizado(usuario)).Returns(true);

            var useCase = new CadastrarUsuarioUseCase(usuario, _usuarioGatewayMock.Object);

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => useCase.Cadastrar());
        }
    }
}