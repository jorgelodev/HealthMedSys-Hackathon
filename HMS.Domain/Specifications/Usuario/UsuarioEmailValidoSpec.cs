using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Specifications;
using HMS.Domain.Specifications.Utils;

namespace HMS.Domain.Specifications.Usuarios
{
    public class UsuarioEmailValidoSpec : ISpecification<Usuario>
    {        
        public string ErrorMessage => "E-mail com formato inválido.";     

        public bool IsSatisfiedBy(Usuario usuario)
        {
            return RegexUtilities.IsValidEmail(usuario.Email);
        }
    }
}
