
namespace HMS.Domain.Entities
{
    public class HorarioDisponivel : EntityBase
    {
        public int Id { get; set; }
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
    }
}
