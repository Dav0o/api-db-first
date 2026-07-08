using api_db_first.DTOs;

namespace api_db_first.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginAsync(LoginRequestDto dto);
        Task<AuthResponseDto?> RegisterAsync(RegisterRequestDto dto);
    }
}
