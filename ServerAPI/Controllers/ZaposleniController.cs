using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orfelin.Core.Interface;
using Orfelin.Core.Models;

namespace Orfelin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZaposleniController : ControllerBase
    {
        private readonly IZaposleniService _zaposleniService;
        public ZaposleniController(IZaposleniService zaposleniService)
        {
            _zaposleniService = zaposleniService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var zaposleni = await _zaposleniService.GetAll();
            return Ok(zaposleni);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var zaposleni = await _zaposleniService.GetAllById(id);
            if (zaposleni == null) return NotFound();
            return Ok(zaposleni);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Zaposleni zaposleni)
        {
            await _zaposleniService.AddASync(zaposleni);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Zaposleni zaposleni)
        {
            await _zaposleniService.UpdateASync(zaposleni);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _zaposleniService.DeleteASync(id);
            return Ok();
        }
    }
}
