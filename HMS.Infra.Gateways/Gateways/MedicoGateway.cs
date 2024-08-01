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

        public Medico Alterar(Medico medico)
        {
            return _medicoRepository.Alterar(medico);
        }

        public Medico Cadastrar(Medico medico)
        {
            return _medicoRepository.Cadastrar(medico);
        }

        public Medico Deletar(int id)
        {
            return _medicoRepository.Deletar(id);
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
