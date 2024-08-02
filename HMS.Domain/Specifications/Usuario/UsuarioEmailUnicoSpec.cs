using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.Interfaces.Specifications;

namespace HMS.Domain.Specifications.Usuarios
{
    public class UsuarioEmailUnicoSpec : ISpecification<Usuario>
    {
        private readonly IUsuarioGateway _usuarioGateway;
        public string ErrorMessage => "E-mail já está sendo utilizado.";

        public UsuarioEmailUnicoSpec(IUsuarioGateway usuarioGateway)
        {
            _usuarioGateway = usuarioGateway;
        }

        public bool IsSatisfiedBy(Usuario usuario)
        {
            return !_usuarioGateway.EmailJaUtilizado(usuario);
        }
    }
}
