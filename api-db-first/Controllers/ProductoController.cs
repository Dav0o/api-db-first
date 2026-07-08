using api_db_first.DTOs;
using api_db_first.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_db_first.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] ProductoListarDto dto)
        {
            var result = await _productoService.ListarAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorID(int id)
        {
            var result = await _productoService.ObtenerPorIDAsync(new ProductoObtenerPorIDDto { ProductoID = id });
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] ProductoInsertarDto dto)
        {
            var result = await _productoService.InsertarAsync(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] ProductoActualizarDto dto)
        {
            var result = await _productoService.ActualizarAsync(dto);
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _productoService.EliminarAsync(new ProductoEliminarDto { ProductoID = id });
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> EliminarFisico(int id)
        {
            var result = await _productoService.EliminarFisicoAsync(new ProductoEliminarFisicoDto { ProductoID = id });
            if (result is null) return NotFound();
            return Ok(result);
        }
    }
}
