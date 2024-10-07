using FenixCoin.Dto.CryptoDTO;

namespace FenixCoin.Services.Interfaces
{
    public interface ICryptoService
    {
        Task<List<CryptoDto>> GetAllCryptos();
        Task<CryptoDto> GetCryptoById(int id);
        Task DeleteCryptoById(int id);
        Task<CryptoDto> UpdateCrypto(int id, UpdateCryptoDto updateCryptoDto);
        Task<AddCryptoDto> AddCrypto(AddCryptoDto addCryptoDto);

    }
}
