using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Specifications;

namespace HMS.Domain.Specifications.Usuarios
{
    public class UsuarioSenhaObrigatorioSpec : ISpecification<Usuario>
    {        
        public string ErrorMessage => "Senha é obrigatório.";     

        public bool IsSatisfiedBy(Usuario usuario)
        {            
            return !string.IsNullOrEmpty(usuario.Senha);
        }
    }
}
