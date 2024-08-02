using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Specifications;

namespace HMS.Domain.Specifications.Medicos
{
    public class MedicoNumeroCRMObrigatorioSpec : ISpecification<Medico>
    {
        public string ErrorMessage => "Número CRM é obrigatório";

        public bool IsSatisfiedBy(Medico medico)
        {
            return !string.IsNullOrEmpty(medico.NumeroCRM);
        }
    }
}
