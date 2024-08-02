using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Specifications;

namespace HMS.Domain.Specifications.Consultas
{    

    public class ConsultaHorarioDisponivelIdObrigatorio : ISpecification<Consulta>
    {
        public string ErrorMessage => "Horario Disponível é obrigatório";

        public bool IsSatisfiedBy(Consulta consulta)
        {
            return consulta.HorarioDisponivelId > 0;
        }
    }
}
