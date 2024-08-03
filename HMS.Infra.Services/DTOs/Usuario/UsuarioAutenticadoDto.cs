using System.Security.Claims;

namespace HMS.Infra.Services.DTOs.Usuarios
{
    public class UsuarioAutenticadoDto
    {
        public UsuarioAutenticadoDto()
        {

            Claims = new List<Claim>();
            

        }
        public int Id { get; set; }        
        public string Email { get; set; }        
        public List<Claim> Claims { get; set; }
    

    }

    
}
