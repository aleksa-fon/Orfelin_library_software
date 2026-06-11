using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Orfelin.Core.Models;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zaposleni>().HasData(new Zaposleni {
                Id = 1,
                Ime = "Admin",
                Prezime = "Admin",
                Username = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("root"),
                Uloga = "Rukovodilac",
                Aktivan = true,
                VremeKreiranja = DateTime.Now
            }); }
        }
    }

