using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orfelin.Core.Interface;
using Orfelin.Core.Models;

namespace Orfelin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KnjigaController : ControllerBase
    {
        private readonly IKnjigaService _knjigaService;
        public KnjigaController(IKnjigaService knjigaService)
        {
            _knjigaService = knjigaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var knjige = await _knjigaService.GetAll();
            return Ok(knjige);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var knjiga = await _knjigaService.GetAllById(id);
            if (knjiga == null) return NotFound();
            return Ok(knjiga);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Knjiga knjiga)
        {
            await _knjigaService.AddASync(knjiga);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Knjiga knjiga)
        {
            await _knjigaService.UpdateASync(knjiga);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _knjigaService.DeleteASync(id);
            return Ok();
        }
    }
}
