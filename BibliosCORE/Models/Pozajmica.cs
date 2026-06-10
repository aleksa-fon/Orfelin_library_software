using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orfelin.Core.Models
{
    public class Pozajmica : BaseEntitiy
    {
        public int KnjigaId { get; set; }
        public Knjiga Knjiga { get; set; } = null!;
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; } = null!;
        public Zaposleni Zaposleni { get; set; } = null!;
        public int ZaposleniId { get; set; }
        public DateTime RokVracanja { get; set; }
        public DateTime DatumPozajmice { get; set; }
        public DateTime? DatumVracanja { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
