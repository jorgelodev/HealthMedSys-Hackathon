using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Specifications;

namespace HMS.Domain.Specifications.Consultas
{

    public class ConsultaPacienteIdObrigatorio : ISpecification<Consulta>
    {
        public string ErrorMessage => "Paciente é obrigatório";

        public bool IsSatisfiedBy(Consulta consulta)
        {
            return consulta.PacienteId > 0;
        }
    }
}
