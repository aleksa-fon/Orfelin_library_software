using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Orfelin.Core.Data
{
    public class OrfelinContext : DbContext
    {
        public OrfelinContext(DbContextOptions<OrfelinContext> options) : base(options)
        {
        }
        public DbSet<Models.Knjiga> Knjige { get; set; }
        public DbSet<Models.Korisnik> Korisnici { get; set; }
        public DbSet<Models.Zaposleni> Zaposleni {  get; set; }
        public DbSet<Models.Pozajmica> Pozajmice { get; set; }
    }
}
