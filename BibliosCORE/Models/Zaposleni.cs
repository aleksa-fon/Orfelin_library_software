using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orfelin.Core.Models
{
    public class Zaposleni : BaseEntitiy
    {
        public string Ime { get; set; } = string.Empty;    
        public string Prezime { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Uloga { get; set; } = string.Empty;
        public bool Aktivan { get; set; } = false;
    }
}
