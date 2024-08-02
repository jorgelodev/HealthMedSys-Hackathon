using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.Interfaces.Specifications;
using HMS.Domain.Specifications.Medicos;

namespace HMS.Domain.UseCases.Medicos
{
    public class CadastrarMedicoUseCase : BaseUseCase<Medico>
    {
        private readonly Medico _medico;
        private readonly IMedicoGateway _medicoGateway;        

        public CadastrarMedicoUseCase(Medico medico, IMedicoGateway medicoGateway) : base(medico)
        {
            _medico = medico;
            _medicoGateway = medicoGateway;
            

            _specifications = new List<ISpecification<Medico>>
            {
                new MedicoNumeroCRMObrigatorioSpec(),
                new MedicoNumeroCRMValidoSpec()
            };
        }

        public Medico Cadastrar()
        {
            ValidaEspecificacoes();            

            return _medico;
        }

    }
}
