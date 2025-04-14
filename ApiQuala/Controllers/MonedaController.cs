using ApiQuala.Core.Domain.Entities;
using ApiQuala.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuala.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MonedaController : ControllerBase
    {
        private readonly IMonedaService _monedaService;

        public MonedaController(IMonedaService monedaService)
        {
            _monedaService = monedaService;
        }


        [HttpGet]
        public async Task<ActionResult<Moneda>> GetAllMonedas()
        {
            var result = await _monedaService.GetAllMonedasAsync();
            if (result == null)
            {
                return NotFound("Monedas no encontrado");
            }
            return Ok(result);
        }
    }
}
