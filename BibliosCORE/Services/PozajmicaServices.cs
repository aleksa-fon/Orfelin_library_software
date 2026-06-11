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
    public class PozajmicaService : IPozajmicaService
    {
        private readonly OrfelinContext _context;
        public PozajmicaService(OrfelinContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Pozajmica>> GetAll()
        {
            return await _context.Pozajmice.ToListAsync();
        }
        public async Task<Pozajmica?> GetAllById(int id)
        {
            return await _context.Pozajmice.FindAsync(id);
        }
        public async Task AddASync(Pozajmica entity)
        {
            await _context.Pozajmice.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateASync(Pozajmica entity)
        {
            _context.Pozajmice.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteASync(int id)
        {
            var pozajmica = await _context.Pozajmice.FindAsync(id);
            if (pozajmica != null)
            {
                _context.Pozajmice.Remove(pozajmica);
                await _context.SaveChangesAsync();
            }
        }
    }
}
