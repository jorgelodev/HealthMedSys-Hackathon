using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Specifications;

namespace HMS.Domain.Specifications.HorarioDisponivels
{
    public class HorarioDisponivelDataInicioValidaSpec : ISpecification<HorarioDisponivel>
    {
        public string ErrorMessage => "Data início deve ser maior que data atual";

        public bool IsSatisfiedBy(HorarioDisponivel horarioDisponivel)
        {
            return horarioDisponivel.DataHoraInicio > DateTime.Now;
        }
    }
}
