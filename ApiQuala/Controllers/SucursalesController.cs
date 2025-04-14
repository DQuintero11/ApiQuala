using ApiQuala.Core.Domain.Entities;
using ApiQuala.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuala.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SucursalesController : ControllerBase
    {
        private readonly ISucursalesService _sucursalesService;

        public SucursalesController(ISucursalesService sucursalesService)
        {
            _sucursalesService = sucursalesService;
        }

        // POST: api/sucursales
        [HttpPost]
        public async Task<IActionResult> PostSucursales(Sucursal sucursal)
        {
            if (sucursal == null)
            {
                return BadRequest("Sucursal no puede ser nulo");
            }

            var result = await _sucursalesService.AddSucursalAsync(sucursal);
            if (result > 0)
            {
                return CreatedAtAction(nameof(GetSucursal), new { id = sucursal.Id }, sucursal);
            }
            return BadRequest("No se pudo crear sucursal.");
        }

        // PUT: api/sucursales/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSucursal(int id, Sucursal sucursal)
        {
            if (id != sucursal.Id)
            {
                return BadRequest("El ID del sucursal no coincide");
            }

            var result = await _sucursalesService.UpdateSucursalAsync(sucursal);
            if (result > 0)
            {
                return NoContent();
            }
            return NotFound("sucursal no encontrado");
        }

        // DELETE: api/sucursales/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursal(int id)
        {
            var result = await _sucursalesService.DeleteSucursalAsync(id);
            if (result > 0)
            {
                return NoContent();
            }
            return NotFound("Sucursal no encontrado");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sucursal>> GetSucursalById(int id)
        {
            var result = await _sucursalesService.GetSucursalByIdAsync(id);
            if (result == null)
            {
                return NotFound("Sucursal no encontrado");
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<SucursalDto>> GetSucursal()
        {
            var result = await _sucursalesService.GetAllSucursalesAsync();
            if (result == null)
            {
                return NotFound("Sucursales no encontrado");
            }
            return Ok(result);
        }
    }
}
