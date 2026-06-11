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
    public class KnjigaService : IKnjigaService
    {
        private readonly OrfelinContext _context;
        public KnjigaService(OrfelinContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Knjiga>> GetAll()
        {
            return await _context.Knjige.ToListAsync();
        }
        public async Task<Knjiga?> GetAllById(int id)
        {
            return await _context.Knjige.FindAsync(id);
        }
        public async Task AddASync(Knjiga entity)
        {
            await _context.Knjige.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateASync(Knjiga entity)
        {
            _context.Knjige.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteASync(int id)
        {
            var knjiga = await _context.Knjige.FindAsync(id);
            if (knjiga != null)
            {
                _context.Knjige.Remove(knjiga);
                await _context.SaveChangesAsync();
            }
        }
    }
}
