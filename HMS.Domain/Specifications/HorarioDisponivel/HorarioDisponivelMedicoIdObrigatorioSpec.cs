using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Specifications;

namespace HMS.Domain.Specifications.HorarioDisponivels
{

    public class HorarioDisponivelMedicoIdObrigatorioSpec : ISpecification<HorarioDisponivel>
    {
        public string ErrorMessage => "Médico é obrigatório";

        public bool IsSatisfiedBy(HorarioDisponivel horarioDisponivel)
        {
            return horarioDisponivel.MedicoId > 0;
        }
    }
}
