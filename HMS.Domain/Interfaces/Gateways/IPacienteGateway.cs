using HMS.Domain.Entities;

namespace HMS.Domain.Interfaces.Gateways
{
    public interface IPacienteGateway
    {
        Paciente Alterar(Paciente paciente);
        Paciente Cadastrar(Paciente paciente);
        Paciente Deletar(int id);
        Paciente ObterPorId(int id);

    }
}
