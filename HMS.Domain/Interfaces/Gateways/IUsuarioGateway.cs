using HMS.Domain.Entities;

namespace HMS.Domain.Interfaces.Gateways
{
    public interface IUsuarioGateway
    {
        Usuario Alterar(Usuario usuario);
        Usuario Cadastrar(Usuario usuario);
        Usuario Deletar(int id);
        Usuario ObterPorId(int id);

    }
}
