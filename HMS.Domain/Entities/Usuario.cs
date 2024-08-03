namespace HMS.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public enum TipoUsuario
        {
            EXTERNO,
            MEDICO,
            PACIENTE
        }
        public TipoUsuario Tipo { get; set; }

    }
    
}
