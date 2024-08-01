using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.Specifications;

namespace HMS.Domain.UseCases.HorarioDisponiveis
{
    public class AlterarHorarioDisponivelUseCase : BaseUseCase<HorarioDisponivel>
    {
        private readonly HorarioDisponivel _horarioDisponivel;
        private readonly IHorarioDisponivelGateway _horarioDisponivelGateway;

        public AlterarHorarioDisponivelUseCase(HorarioDisponivel horarioDisponivel, IHorarioDisponivelGateway horarioDisponivelGateway) : base(horarioDisponivel)
        {
            _horarioDisponivel = horarioDisponivel;
            _horarioDisponivelGateway = horarioDisponivelGateway;

            _specifications = new List<ISpecification<HorarioDisponivel>>
            {
                //new LivroDoadorExisteSpec(_pacienteGateway)
            };
        }

        public HorarioDisponivel Alterar()
        {
            ValidaEspecificacoes();

            //_paciente.Disponivel = true;

            return _horarioDisponivel;
        }

    }
}
