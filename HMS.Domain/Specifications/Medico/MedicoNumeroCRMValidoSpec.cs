using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Specifications;

namespace HMS.Domain.Specifications.Medicos
{
    public class MedicoNumeroCRMValidoSpec : ISpecification<Medico>
    {
        public string ErrorMessage => "Número CRM com formato inválido. Mín e Máx de 13 caracteres.";

        public bool IsSatisfiedBy(Medico medico)
        {
            return medico.NumeroCRM.Length == 13;
        }
    }
}
