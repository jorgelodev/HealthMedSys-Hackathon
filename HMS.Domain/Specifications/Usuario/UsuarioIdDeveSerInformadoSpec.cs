using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Specifications;

namespace HMS.Domain.Specifications.Usuarios
{
    public class UsuarioIdDeveSerInformadoSpec : ISpecification<Usuario>
    {
        public string ErrorMessage => "Id usuário não informado";

        public bool IsSatisfiedBy(Usuario usuario)
        {
            return usuario.Id > 0;
        }
    }
}
