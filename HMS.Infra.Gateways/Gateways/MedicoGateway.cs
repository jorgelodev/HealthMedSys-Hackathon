using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.Interfaces.Repositories;

namespace HMS.Infra.Gateways.Gateways
{
    public class MedicoGateway : IMedicoGateway
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoGateway(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public Medico Cadastrar(Medico medico)
        {
            return _medicoRepository.Cadastrar(medico);
        }

        public ICollection<Medico> Disponiveis()
        {
           
           return _medicoRepository.Disponiveis();
        }

        public Medico ObterPorId(int id)
        {
            return _medicoRepository.ObterPorId(id);
        }
    }
}
