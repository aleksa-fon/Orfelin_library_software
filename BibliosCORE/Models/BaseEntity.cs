namespace Orfelin.Core.Models
{
    public abstract class BaseEntitiy
    {
        public int Id { get; set; }
        public DateTime VremeKreiranja { get; set; }

        public DateTime? VremeIzmene { get; set; }
    }
}
