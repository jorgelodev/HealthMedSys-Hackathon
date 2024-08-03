using AutoMapper;
using HMS.Domain.Entities;
using HMS.Domain.Excepctions;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.UseCases.Medicos;
using HMS.Domain.UseCases.Pessoas;
using HMS.Domain.UseCases.Usuarios;
using HMS.Infra.Services.DTOs.Medicos;
using HMS.Infra.Services.Interfaces;

namespace HMS.Infra.Services.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoGateway _medicoGateway;        
        private readonly IUsuarioGateway _usuarioGateway;        
        private readonly IMapper _mapper;        

        public MedicoService(IMedicoGateway medicoGateway, IMapper mapper, IUsuarioGateway usuarioGateway)
        {
            _medicoGateway = medicoGateway;
            _mapper = mapper;
            _usuarioGateway = usuarioGateway;
        }


        public MedicoDto Cadastrar(CadastraMedicoDto medicoDto)
        {
            var medico = _mapper.Map<Medico>(medicoDto);
            var usuario = _mapper.Map<Usuario>(medicoDto);

            usuario.Tipo = Usuario.TipoUsuario.MEDICO;

            var cadastrarUsuarioUseCase = new CadastrarUsuarioUseCase(usuario, _usuarioGateway);

            usuario = cadastrarUsuarioUseCase.Cadastrar();

            var cadastrarMedicoUseCase = new CadastrarMedicoUseCase(medico, _medicoGateway);            

            medico = cadastrarMedicoUseCase.Cadastrar();

            var cadastrarpessoaUseCase = new CadastrarPessoaUseCase(medico);

            cadastrarpessoaUseCase.Cadastrar();

            usuario = _usuarioGateway.Cadastrar(usuario);

            medico.Usuario = usuario;
            medico.UsuarioId = usuario.Id;

            medico = _medicoGateway.Cadastrar(medico);
            
            var medicoCadastradoDto = _mapper.Map<MedicoDto>(medico);

            medicoCadastradoDto.Email = medico.Usuario.Email;

            return medicoCadastradoDto;
        }

     

        public ICollection<MedicosDisponiveisDto> Disponiveis()
        {

            return _mapper.Map<List<MedicosDisponiveisDto>>(_medicoGateway.Disponiveis());            
        }

        public MedicoDto ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
