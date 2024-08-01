using HMS.Domain.Entities;

namespace HMS.Domain.Interfaces.Gateways
{
    public interface IHorarioDisponivelGateway
    {
        HorarioDisponivel Alterar(HorarioDisponivel horarioDisponivel);
        HorarioDisponivel Cadastrar(HorarioDisponivel horarioDisponivel);
        HorarioDisponivel Deletar(int id);
        HorarioDisponivel ObterPorId(int id);

    }
}
