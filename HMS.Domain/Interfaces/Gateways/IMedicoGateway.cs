using HMS.Domain.Entities;

namespace HMS.Domain.Interfaces.Gateways
{
    public interface IMedicoGateway
    {     
        Medico Cadastrar(Medico paciente);    
        Medico ObterPorId(int id);
        ICollection<Medico> Disponiveis();
    }
}
