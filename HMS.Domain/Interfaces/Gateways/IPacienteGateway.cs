using HMS.Domain.Entities;

namespace HMS.Domain.Interfaces.Gateways
{
    public interface IPacienteGateway
    {
        Paciente Cadastrar(Paciente paciente);
        Paciente ObterPorId(int id);
        Paciente ObterPorIdUsuario(int usuarioId);
    }
}
