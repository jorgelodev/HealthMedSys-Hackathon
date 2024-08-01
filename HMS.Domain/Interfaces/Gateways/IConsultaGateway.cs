using HMS.Domain.Entities;

namespace HMS.Domain.Interfaces.Gateways
{
    public interface IConsultaGateway
    {
        Consulta Cadastrar(Consulta consulta);
        Consulta BuscarConsultaCompleta(int id);

    }
}
