using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Orfelin.Core.Data;
using Orfelin.Core.Interface;
using Orfelin.Core.Models;

namespace Orfelin.Core.Services
{
    public class KorisnikSERVISI : IKorisnikService
    {
        private readonly OrfelinContext _context;
        public KorisnikSERVISI(OrfelinContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Korisnik>> GetAll()
        {
            return await _context.Korisnici.ToListAsync();
        }
        public async Task<Korisnik?> GetAllById(int id)
        {
            return await _context.Korisnici.FindAsync(id);
        }
        public async Task AddASync(Korisnik entity)
        {
            await _context.Korisnici.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateASync(Korisnik entity)
        {
            _context.Korisnici.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteASync(int id)
        {
            var korisnik = await _context.Korisnici.FindAsync(id);
            if (korisnik != null)
            {
                _context.Korisnici.Remove(korisnik);
                await _context.SaveChangesAsync();
            }
        }
    }
}
