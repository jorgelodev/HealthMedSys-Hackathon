using AutoMapper;
using HMS.Domain.Entities;
using HMS.Domain.Excepctions;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.UseCases.Medicos;
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

        public AlteraMedicoDto Alterar(AlteraMedicoDto alteraMedicoDto)
        {
            var medico = _medicoGateway.ObterPorId(alteraMedicoDto.Id) ??
                throw new DomainValidationException("Médico não encontrado");

            medico.Nome = alteraMedicoDto.Nome;

            var alterarMedicoUseCase = new AlterarMedicoUseCase(medico, _medicoGateway);

            alterarMedicoUseCase.Alterar();

            return _mapper.Map<AlteraMedicoDto>(_medicoGateway.Alterar(medico));
        }

        public MedicoDto Cadastrar(CadastraMedicoDto medicoDto)
        {
            var medico = _mapper.Map<Medico>(medicoDto);
            var usuario = _mapper.Map<Usuario>(medicoDto);

            var cadastrarUsuarioUseCase = new CadastrarUsuarioUseCase(usuario, _usuarioGateway);

            usuario = cadastrarUsuarioUseCase.Cadastrar();
            
            usuario = _usuarioGateway.Cadastrar(usuario);

            medico.Usuario = usuario;            
            medico.UsuarioId = usuario.Id;

            var cadastrarMedicoUseCase = new CadastrarMedicoUseCase(medico, _medicoGateway);            

            medico = cadastrarMedicoUseCase.Cadastrar();

            medico = _medicoGateway.Cadastrar(medico);
            
            var medicoCadastradoDto = _mapper.Map<MedicoDto>(medico);

            medicoCadastradoDto.Email = medico.Usuario.Email;

            return medicoCadastradoDto;
        }

        public MedicoDto Deletar(int id)
        {
            throw new NotImplementedException();
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
