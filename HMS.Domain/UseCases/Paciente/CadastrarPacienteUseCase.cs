using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.Interfaces.Specifications;

namespace HMS.Domain.UseCases.Pacientes
{
    public class CadastrarPacienteUseCase : BaseUseCase<Paciente>
    {
        private readonly Paciente _paciente;
        private readonly IPacienteGateway _pacienteGateway;        

        public CadastrarPacienteUseCase(Paciente paciente, IPacienteGateway pacienteGateway) : base(paciente)
        {
            _paciente = paciente;
            _pacienteGateway = pacienteGateway;
            

            _specifications = new List<ISpecification<Paciente>>
            {                
            };
        }

        public Paciente Cadastrar()
        {
            ValidaEspecificacoes();            

            return _paciente;
        }

    }
}
