using Microsoft.EntityFrameworkCore;
using Orfelin.Core.Data;
using Orfelin.Core.DTO;
using Orfelin.Core.Interface;

namespace Orfelin.Core.Services
{
    public class AuthServices : IAuthService
    {
        protected readonly OrfelinContext _context;
        public AuthServices(OrfelinContext context)
        {
            _context = context;
        }
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var zaposleni = await _context.Zaposleni.FirstOrDefaultAsync(z => z.Username == request.Username);

            if (zaposleni == null)
            {
                return new LoginResponse { Success = false, Message = "Pogrešno korisničko ime." };
            }

            bool ispravnaLozinka = BCrypt.Net.BCrypt.Verify(request.Password, zaposleni.PasswordHash);

            if (!ispravnaLozinka)
                return new LoginResponse { Success = false, Message = "Pogrešna lozinka" };

            return new LoginResponse
            {
                Success = true,
                Ime = zaposleni.Ime,
                Prezime = zaposleni.Prezime,
                Uloga = zaposleni.Uloga,
                Message = "Uspešna prijava na sistem."
            };
        }
    }
}
