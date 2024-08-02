namespace HMS.Infra.Services.DTOs.HorarioDisponiveis
{
    public class CadastraHorarioDisponivelDto
    {        
        public int MedicoId { get; set; }
        
        public DateTime DataHoraInicio { get; set; }
        
        public DateTime DataHoraFim { get; set; }
    }
}
