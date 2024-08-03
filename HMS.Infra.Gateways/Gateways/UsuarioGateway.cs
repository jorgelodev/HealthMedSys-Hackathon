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
        public Usuario Cadastrar(Usuario usuario)
        {
            return _usuarioRepository.Cadastrar(usuario);
        }

        public Usuario ObterPorId(int id)
        {
            return _usuarioRepository.ObterPorId(id);
        }

        public bool EmailJaUtilizado(Usuario usuario)
        {            

            var usuarioComMesmoEmail = _usuarioRepository
                .Buscar(u => u.Email.Equals(usuario.Email) && u.Id != usuario.Id)
                .FirstOrDefault();

            return usuarioComMesmoEmail != null;
        }

        public Usuario BuscarPorEmail(string email)
        {
            return _usuarioRepository
                .Buscar(u => email.Equals(u.Email))
                .FirstOrDefault();
        }
    }
}
