using AutoMapper;
using HMS.Domain.Entities;
using HMS.Domain.Excepctions;
using HMS.Domain.Interfaces.Gateways;
using HMS.Infra.Services.DTOs.Usuarios;
using HMS.Infra.Services.Interfaces;
using System.Security.Claims;

namespace HMS.Infra.Services.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioGateway _usuarioGateway;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioGateway usuarioGateway, IMapper mapper)
        {
            _usuarioGateway = usuarioGateway;
            _mapper = mapper;
        }

        public UsuarioAutenticadoDto AutenticarUsuario(UsuarioLogonDto usuarioLogonDto)
        {
            if(string.IsNullOrEmpty(usuarioLogonDto.Email) || string.IsNullOrEmpty(usuarioLogonDto.Senha))
            {
                throw new DomainValidationException("Senha e/ou e-mail inválido(s).");
            }
            var usuario = _usuarioGateway.BuscarPorEmail(usuarioLogonDto.Email) ??
                throw new DomainValidationException("Senha e/ou e-mail inválido(s).");

            if (usuario.Senha != usuarioLogonDto.Senha)
            {
                throw new DomainValidationException("Senha e/ou e-mail inválido(s).");
            }

            var usuarioAutenticado = _mapper.Map<UsuarioAutenticadoDto>(usuario);

            if (usuario.Tipo == Usuario.TipoUsuario.MEDICO)
            {
                usuarioAutenticado.Claims.Add(new Claim(ClaimTypes.Role, "Medico"));
            }
            else if (usuario.Tipo == Usuario.TipoUsuario.PACIENTE)
            {
                usuarioAutenticado.Claims.Add(new Claim(ClaimTypes.Role, "Paciente"));
            }

            return usuarioAutenticado;

        }
    }
}
