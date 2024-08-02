using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Specifications;

namespace HMS.Domain.Specifications.Pessoas
{
    public class PessoaCPFObrigatorioSpec : ISpecification<Pessoa>
    {        
        public string ErrorMessage => "CPF é obrigatório";

        public bool IsSatisfiedBy(Pessoa pessoa)
        {
            return !string.IsNullOrEmpty(pessoa.CPF);
        }
    }
}
