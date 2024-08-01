namespace HMS.Domain.Entities
{
    public class Consulta : EntityBase
    {
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int HorarioDisponivelId { get; set; }
        public HorarioDisponivel HorarioDisponivel { get; set; }
    }
}
