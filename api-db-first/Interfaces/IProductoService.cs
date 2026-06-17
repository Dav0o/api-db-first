using api_db_first.DTOs;
using api_db_first.Models;

namespace api_db_first.Interfaces
{
    public interface IProductoService
    {
        Task<List<ProductoResult>> ListarAsync(ProductoListarDto dto);
        Task<ProductoResult?> ObtenerPorIDAsync(ProductoObtenerPorIDDto dto);
        Task<ProductoResult?> InsertarAsync(ProductoInsertarDto dto);
        Task<ProductoResult?> ActualizarAsync(ProductoActualizarDto dto);
        Task<MensajeResult?> EliminarAsync(ProductoEliminarDto dto);
        Task<MensajeResult?> EliminarFisicoAsync(ProductoEliminarFisicoDto dto);
    }
}
