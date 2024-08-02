using HMS.Domain.Entities;

namespace HMS.Domain.Interfaces.Gateways
{
    public interface IUsuarioGateway
    {
        Usuario Cadastrar(Usuario usuario);
        Usuario ObterPorId(int id);
        bool EmailJaUtilizado(Usuario usuario);
    }
}
