using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.Interfaces.Specifications;

namespace HMS.Domain.Specifications.HorarioDisponivels
{
    public class HorarioDisponiveDesocupadoSpec : ISpecification<HorarioDisponivel>
    {
        private readonly IHorarioDisponivelGateway _horarioDisponivelGateway;

        public HorarioDisponiveDesocupadoSpec(IHorarioDisponivelGateway horarioDisponivelGateway)
        {
            _horarioDisponivelGateway = horarioDisponivelGateway;
        }

        public string ErrorMessage => "Já existe um horário cadastrado para essa Data/hora";

        public bool IsSatisfiedBy(HorarioDisponivel horarioDisponivel)
        {
            return _horarioDisponivelGateway.HorarioEstaDesocupado(horarioDisponivel);
        }
    }
}
