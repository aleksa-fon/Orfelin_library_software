using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orfelin.Core.Interface;
using Orfelin.Core.Models;

namespace Orfelin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PozajmicaController : ControllerBase
    {
        private readonly IPozajmicaService _pozajmicaService;
        public PozajmicaController(IPozajmicaService pozajmicaService)
        {
            _pozajmicaService = pozajmicaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pozajmice = await _pozajmicaService.GetAll();
            return Ok(pozajmice);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pozajmica = await _pozajmicaService.GetAllById(id);
            if (pozajmica == null) return NotFound();
            return Ok(pozajmica);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Pozajmica pozajmica)
        {
            await _pozajmicaService.AddASync(pozajmica);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Pozajmica pozajmica)
        {
            await _pozajmicaService.UpdateASync(pozajmica);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _pozajmicaService.DeleteASync(id);
            return Ok();
        }
    }
}
