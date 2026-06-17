using api_db_first.Data;
using api_db_first.DTOs;
using api_db_first.Interfaces;
using api_db_first.Models;

namespace api_db_first.Services
{
    public class ProductoService : IProductoService
    {
        private readonly AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductoResult>> ListarAsync(ProductoListarDto dto)
        {
            return await _context.sp_Productos_Listar(
                dto.Nombre,
                dto.SoloActivos,
                dto.PrecioMinimo,
                dto.PrecioMaximo,
                dto.PageNumber,
                dto.PageSize
            );
        }

        public async Task<ProductoResult?> ObtenerPorIDAsync(ProductoObtenerPorIDDto dto)
        {
            return await _context.sp_Productos_ObtenerPorID(dto.ProductoID);
        }

        public async Task<ProductoResult?> InsertarAsync(ProductoInsertarDto dto)
        {
            return await _context.sp_Productos_Insertar(
                dto.Nombre,
                dto.Precio,
                dto.Stock,
                dto.Descripcion,
                dto.Activo
            );
        }

        public async Task<ProductoResult?> ActualizarAsync(ProductoActualizarDto dto)
        {
            return await _context.sp_Productos_Actualizar(
                dto.ProductoID,
                dto.Nombre,
                dto.Descripcion,
                dto.Precio,
                dto.Stock,
                dto.Activo
            );
        }

        public async Task<MensajeResult?> EliminarAsync(ProductoEliminarDto dto)
        {
            return await _context.sp_Productos_Eliminar(dto.ProductoID);
        }

        public async Task<MensajeResult?> EliminarFisicoAsync(ProductoEliminarFisicoDto dto)
        {
            return await _context.sp_Productos_EliminarFisico(dto.ProductoID);
        }
    }
}
