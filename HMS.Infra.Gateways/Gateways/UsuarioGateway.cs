using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.Interfaces.Repositories;

namespace HMS.Infra.Gateways.Gateways
{
    public class UsuarioGateway : IUsuarioGateway
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioGateway(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Alterar(Usuario usuario)
        {
            return _usuarioRepository.Alterar(usuario);
        }

        public Usuario Cadastrar(Usuario usuario)
        {
            return _usuarioRepository.Cadastrar(usuario);
        }

        public Usuario Deletar(int id)
        {
            return _usuarioRepository.Deletar(id);
        }

        public Usuario ObterPorId(int id)
        {
            return _usuarioRepository.ObterPorId(id);
        }
    }
}
