using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Specifications;
using HMS.Domain.Specifications.Pessoas;

namespace HMS.Domain.UseCases.Pessoas
{
    public class CadastrarPessoaUseCase : BaseUseCase<Pessoa>
    {
        private readonly Pessoa _pessoa;


        public CadastrarPessoaUseCase(Pessoa pessoa) : base(pessoa)
        {
            _pessoa = pessoa;

            _specifications = new List<ISpecification<Pessoa>>
            {
                new PessoaNomeObrigatorioSpec(),
                new PessoaCPFObrigatorioSpec(),
                new PessoaCPFValidoSpec(),
            };
        }

        public Pessoa Cadastrar()
        {
            ValidaEspecificacoes();

            return _pessoa;
        }

    }
}
