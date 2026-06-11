using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orfelin.Core.Interface;
using Orfelin.Core.Models;

namespace Orfelin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService _korisnikService;
        public KorisnikController(IKorisnikService korisnikService)
        {
            _korisnikService = korisnikService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var korisnici = await _korisnikService.GetAll();
            return Ok(korisnici);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var korisnik = await _korisnikService.GetAllById(id);
            if (korisnik == null) return NotFound();
            return Ok(korisnik);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Korisnik korisnik)
        {
            await _korisnikService.AddASync(korisnik);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Korisnik korisnik)
        {
            await _korisnikService.UpdateASync(korisnik);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _korisnikService.DeleteASync(id);
            return Ok();
        }
    }
}
