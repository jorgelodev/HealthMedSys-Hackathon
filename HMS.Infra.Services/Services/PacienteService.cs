using AutoMapper;
using HMS.Domain.Entities;
using HMS.Domain.Excepctions;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.UseCases.Pacientes;
using HMS.Domain.UseCases.Usuarios;
using HMS.Infra.Services.DTOs.Pacientes;
using HMS.Infra.Services.Interfaces;

namespace HMS.Infra.Services.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteGateway _pacienteGateway;        
        private readonly IUsuarioGateway _usuarioGateway;        
        private readonly IMapper _mapper;

        public PacienteService(IPacienteGateway pacienteGateway, IMapper mapper, IUsuarioGateway usuarioGateway)
        {
            _pacienteGateway = pacienteGateway;
            _mapper = mapper;
            _usuarioGateway = usuarioGateway;
        }

        public AlteraPacienteDto Alterar(AlteraPacienteDto alteraPacienteDto)
        {
            var paciente = _pacienteGateway.ObterPorId(alteraPacienteDto.Id) ??
                throw new DomainValidationException("Paciente não encontrado");

            paciente.Nome = alteraPacienteDto.Nome;

            var alterarPacienteUseCase = new AlterarPacienteUseCase(paciente, _pacienteGateway);

            alterarPacienteUseCase.Alterar();

            return _mapper.Map<AlteraPacienteDto>(_pacienteGateway.Alterar(paciente));
        }

        public PacienteDto Cadastrar(CadastraPacienteDto pacienteDto)
        {
            var paciente = _mapper.Map<Paciente>(pacienteDto);
            var usuario = _mapper.Map<Usuario>(pacienteDto);

            var cadastrarUsuarioUseCase = new CadastrarUsuarioUseCase(usuario, _usuarioGateway);

            usuario = cadastrarUsuarioUseCase.Cadastrar();
            
            usuario = _usuarioGateway.Cadastrar(usuario);

            paciente.Usuario = usuario;            
            paciente.UsuarioId = usuario.Id;

            var cadastrarPacienteUseCase = new CadastrarPacienteUseCase(paciente, _pacienteGateway);            

            paciente = cadastrarPacienteUseCase.Cadastrar();

            paciente = _pacienteGateway.Cadastrar(paciente);

            var pacienteCadastradoDto = _mapper.Map<PacienteDto>(paciente);
            
            pacienteCadastradoDto.Email = paciente.Usuario.Email;

            return pacienteCadastradoDto;
        }

        public PacienteDto Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public PacienteDto ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
