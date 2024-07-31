using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.Specifications;

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
                //new LivroDoadorExisteSpec(_pacienteGateway)
            };
        }

        public Usuario Cadastrar()
        {
            ValidaEspecificacoes();

            //_paciente.Disponivel = true;

            return _usuario;
        }

    }
}
