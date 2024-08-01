using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.Specifications;

namespace HMS.Domain.UseCases.Consultas
{
    
    public class AgendarConsultaUseCase : BaseUseCase<Consulta>
    {
        private readonly Consulta _consulta;
        private readonly IConsultaGateway _consultaGateway;

        public AgendarConsultaUseCase(Consulta consulta, IConsultaGateway consultaGateway) : base(consulta)
        {
            _consulta = consulta;
            _consultaGateway = consultaGateway;


            _specifications = new List<ISpecification<Consulta>>
            {
                //new LivroDoadorExisteSpec(_pacienteGateway)
            };
        }

        public Consulta Agendar()
        {
            ValidaEspecificacoes();

            //_paciente.Disponivel = true;

            return _consulta;
        }

    }
}
