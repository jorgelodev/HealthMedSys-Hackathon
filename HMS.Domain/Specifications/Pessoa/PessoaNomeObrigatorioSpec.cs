using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Specifications;

namespace HMS.Domain.Specifications.Pessoas
{
    public class PessoaNomeObrigatorioSpec : ISpecification<Pessoa>
    {        
        public string ErrorMessage => "Nome é obrigatório.";

        public bool IsSatisfiedBy(Pessoa pessoa)
        {
            return !string.IsNullOrEmpty(pessoa.Nome);
        }
    }
}
