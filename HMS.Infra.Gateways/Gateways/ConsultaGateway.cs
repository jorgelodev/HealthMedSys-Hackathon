using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.Interfaces.Repositories;

namespace HMS.Infra.Gateways.Gateways
{
    public class ConsultaGateway : IConsultaGateway
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaGateway(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public Consulta BuscarConsultaCompleta(int id)
        {
            return _consultaRepository.BuscarContultaCompleta(id);
        }

        public Consulta Cadastrar(Consulta consulta)
        {
            return _consultaRepository.Cadastrar(consulta);
        }

       
    }
}
