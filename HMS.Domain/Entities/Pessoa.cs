
namespace HMS.Domain.Entities
{
    public abstract class Pessoa : EntityBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}
