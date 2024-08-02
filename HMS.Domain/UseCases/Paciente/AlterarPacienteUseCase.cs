using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.Interfaces.Specifications;

namespace HMS.Domain.UseCases.Pacientes
{
    public class AlterarPacienteUseCase : BaseUseCase<Paciente>
    {
        private readonly Paciente _paciente;
        private readonly IPacienteGateway _pacienteGateway;

        public AlterarPacienteUseCase(Paciente paciente, IPacienteGateway pacienteGateway) : base(paciente)
        {
            _paciente = paciente;
            _pacienteGateway = pacienteGateway;

            _specifications = new List<ISpecification<Paciente>>
            {
                //new LivroDoadorExisteSpec(_pacienteGateway)
            };
        }

        public Paciente Alterar()
        {
            ValidaEspecificacoes();

            //_paciente.Disponivel = true;

            return _paciente;
        }

    }
}
