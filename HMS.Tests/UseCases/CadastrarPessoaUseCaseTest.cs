using Bogus;
using HMS.Domain.Entities;
using HMS.Domain.Excepctions;
using HMS.Domain.UseCases.Pessoas;

namespace HMS.Tests.UseCases
{
    public class CadastrarPessoaUseCaseTests
    {
        private readonly Faker<Pessoa> _pessoaFaker;

        public CadastrarPessoaUseCaseTests()
        {
            _pessoaFaker = new Faker<Pessoa>()
                .RuleFor(p => p.Id, f => f.Random.Int(1, 1000))
                .RuleFor(p => p.Nome, f => f.Name.FullName())
                .RuleFor(p => p.CPF, f => "12345678901");
        }

        [Fact]
        public void Cadastrar_DeveRetornarPessoaQuandoValido()
        {
            // Arrange
            var pessoa = _pessoaFaker.Generate();
            var useCase = new CadastrarPessoaUseCase(pessoa);

            // Act
            var result = useCase.Cadastrar();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(pessoa.Id, result.Id);
            Assert.Equal(pessoa.Nome, result.Nome);
            Assert.Equal(pessoa.CPF, result.CPF);
        }

        [Fact]
        public void Cadastrar_DeveLancarExcecaoQuandoNomeInvalido()
        {
            // Arrange
            var pessoa = _pessoaFaker.Generate();
            pessoa.Nome = ""; 
            var useCase = new CadastrarPessoaUseCase(pessoa);

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => useCase.Cadastrar());
        }

        [Fact]
        public void Cadastrar_DeveLancarExcecaoQuandoCPFInvalido()
        {
            // Arrange
            var pessoa = _pessoaFaker.Generate();
            pessoa.CPF = ""; 
            var useCase = new CadastrarPessoaUseCase(pessoa);

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => useCase.Cadastrar());
        }

        [Fact]
        public void Cadastrar_DeveLancarExcecaoQuandoCPFMalFormado()
        {
            // Arrange
            var pessoa = _pessoaFaker.Generate();
            pessoa.CPF = "123456789"; 
            var useCase = new CadastrarPessoaUseCase(pessoa);

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => useCase.Cadastrar());
        }
    }
}
