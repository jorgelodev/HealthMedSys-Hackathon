using HMS.Infra.Services.DTOs.HorarioDisponiveis;

namespace HMS.Infra.Services.DTOs.Medicos
{
    public class MedicosDisponiveisDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NumeroCRM { get; set; }

        public ICollection<HorarioDisponivelListaMedicoDto> HorariosDisponiveis { get; set; }
    }
}
