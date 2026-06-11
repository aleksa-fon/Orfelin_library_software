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
    public class ZaposleniService : IZaposleniService
    {
        private readonly OrfelinContext _context;
        public ZaposleniService(OrfelinContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Zaposleni>> GetAll()
        {
            return await _context.Zaposleni.ToListAsync();
        }
        public async Task<Zaposleni?> GetAllById(int id)
        {
            return await _context.Zaposleni.FindAsync(id);
        }
        public async Task AddASync(Zaposleni entity)
        {
            await _context.Zaposleni.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateASync(Zaposleni entity)
        {
            _context.Zaposleni.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteASync(int id)
        {
            var zaposleni = await _context.Zaposleni.FindAsync(id);
            if (zaposleni != null)
            {
                _context.Zaposleni.Remove(zaposleni);
                await _context.SaveChangesAsync();
            }
        }
    }
}
