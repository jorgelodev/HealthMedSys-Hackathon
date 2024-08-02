using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Specifications;

namespace HMS.Domain.Specifications.Pessoas
{
    public class PessoaCPFValidoSpec : ISpecification<Pessoa>
    {        
        public string ErrorMessage => "CPF formato inválido. Mín e máx 11 caracteres.";

        public bool IsSatisfiedBy(Pessoa pessoa)
        {
            return pessoa.CPF.Length == 11;
        }
    }
}
