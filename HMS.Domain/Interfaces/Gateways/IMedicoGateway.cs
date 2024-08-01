using HMS.Domain.Entities;

namespace HMS.Domain.Interfaces.Gateways
{
    public interface IMedicoGateway
    {
        Medico Alterar(Medico paciente);
        Medico Cadastrar(Medico paciente);
        Medico Deletar(int id);
        Medico ObterPorId(int id);

        ICollection<Medico> Disponiveis();

    }
}
