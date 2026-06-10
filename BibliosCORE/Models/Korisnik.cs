using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orfelin.Core.Models
{
    public class Korisnik : BaseEntitiy
    {
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string BrojClanskeKarte { get; set; } = string.Empty;
        public DateTime DatumClanstva { get; set; }
        public bool Aktivan { get; set; } = false;    
    }
}
