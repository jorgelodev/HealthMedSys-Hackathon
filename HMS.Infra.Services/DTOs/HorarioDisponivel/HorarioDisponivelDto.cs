namespace HMS.Infra.Services.DTOs.HorarioDisponiveis
{
    public class HorarioDisponivelDto
    {
        public int Id { get; set; }
        public int MedicoId { get; set; }        
        public string Medico { get; set; }        
        public DateTime DataHoraInicio { get; set; }
        
        public DateTime DataHoraFim { get; set; }
        
    }
}
