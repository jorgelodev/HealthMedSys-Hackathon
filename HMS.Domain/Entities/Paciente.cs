namespace HMS.Domain.Entities
{
    public class Paciente : Pessoa
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        override public string ToString()
        {
            return Nome;
        }
    }

   
}
