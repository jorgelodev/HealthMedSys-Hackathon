using HMS.Infra.Services.DTOs.Usuarios;

namespace HMS.Infra.Services.DTOs.HorarioDisponiveis
{
    public class AgendaConsultaDto
    {
        public UsuarioAutenticadoDto UsuarioAutenticadoDto { get; set; }
        public int IdUsuarioSolicitante { get; set; }        
        public int HorarioDisponivelId { get; set; }        
    }
}
