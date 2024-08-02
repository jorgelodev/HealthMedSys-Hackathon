using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.Interfaces.Specifications;
using HMS.Domain.Specifications.Usuarios;

namespace HMS.Domain.UseCases.Usuarios
{
    public class CadastrarUsuarioUseCase : BaseUseCase<Usuario>
    {
        private readonly Usuario _usuario;
        private readonly IUsuarioGateway _usuarioGateway;

        public CadastrarUsuarioUseCase(Usuario usuario, IUsuarioGateway usuarioGateway) : base(usuario)
        {
            _usuario = usuario;
            _usuarioGateway = usuarioGateway;


            _specifications = new List<ISpecification<Usuario>>
            {
                new UsuarioEmailUnicoSpec(_usuarioGateway),
                new UsuarioSenhaObrigatorioSpec(),
                new UsuarioEmailValidoSpec()
            };
        }

        public Usuario Cadastrar()
        {
            ValidaEspecificacoes();            

            return _usuario;
        }

    }
}
