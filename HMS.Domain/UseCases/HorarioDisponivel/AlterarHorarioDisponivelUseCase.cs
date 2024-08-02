using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.Interfaces.Specifications;
using HMS.Domain.Specifications.HorarioDisponivels;

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
                new HorarioDisponivelMedicoIdObrigatorioSpec(),
                new HorarioDisponivelDataInicioValidaSpec(),
                new HorarioDisponivelDataFimValidaSpec(),
                new HorarioDisponivelDatasValidaSpec(),
            };
        }

        public HorarioDisponivel Alterar()
        {
            ValidaEspecificacoes();           

            return _horarioDisponivel;
        }

    }
}
