
namespace HMS.Domain.Entities
{
    public class Medico : Pessoa
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string NumeroCRM { get; set; }

        public ICollection<HorarioDisponivel> HorariosDisponiveis { get; set; }

        override public string ToString()
        {
            return Nome;
        }
    }
}
