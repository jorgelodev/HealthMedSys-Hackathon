using HMS.Domain.Entities;
using HMS.Infra.Services.DTOs.Usuarios;
using System.Security.Claims;

namespace HMS.Infra.Services.Interfaces
{
    public interface IUsuarioService
    {
       

        UsuarioAutenticadoDto AutenticarUsuario(UsuarioLogonDto usuario);
            
    }
}
