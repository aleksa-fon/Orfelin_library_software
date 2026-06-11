using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orfelin.Core.DTO
{
    public class LoginResponse
    {
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;

        public string Uloga { get; set; } = string.Empty;

        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
