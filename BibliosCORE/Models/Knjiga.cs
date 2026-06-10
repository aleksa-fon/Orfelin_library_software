using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orfelin.Core.Models
{
    public class Knjiga : BaseEntitiy
    {
        public int InventarniBroj { get; set; }
        public string Naslov { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Izdavac { get; set; } = string.Empty;
        public int GodinaIzdavanja { get; set; }
        public string Zanr { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int BrojStrana { get; set; }
        public int DostupnoKopija { get; set; }
        public int UkupanBrojKopija { get; set; }
        public DateTime DatumNabavke { get; set; }
    }
}
