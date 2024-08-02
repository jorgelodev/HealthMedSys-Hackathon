using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.Interfaces.Repositories;

namespace HMS.Infra.Gateways.Gateways
{
    public class PacienteGateway : IPacienteGateway
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteGateway(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }
        public Paciente Cadastrar(Paciente paciente)
        {
            return _pacienteRepository.Cadastrar(paciente);
        }

        public Paciente ObterPorId(int id)
        {
            return _pacienteRepository.ObterPorId(id);
        }
    }
}
