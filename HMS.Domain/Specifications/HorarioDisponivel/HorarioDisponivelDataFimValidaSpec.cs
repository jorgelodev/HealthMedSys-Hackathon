using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Specifications;

namespace HMS.Domain.Specifications.HorarioDisponivels
{
    public class HorarioDisponivelDataFimValidaSpec : ISpecification<HorarioDisponivel>
    {
        public string ErrorMessage => "Data Fim deve ser superior a Data Início";

        public bool IsSatisfiedBy(HorarioDisponivel horarioDisponivel)
        {
            return horarioDisponivel.DataHoraFim > horarioDisponivel.DataHoraInicio;
        }
    }
}
