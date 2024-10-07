using AutoMapper;
using FenixCoin.DataAccess.Repositories;
using FenixCoin.Domain.Models;
using FenixCoin.Dto.CryptoDTO;
using FenixCoin.Services.Interfaces;
using FenixCoin.Shared;
using FenixCoin.Shared.CryptoExceptions;

namespace FenixCoin.Services.Implementation
{
    public class CryptoService : ICryptoService
    {

        private readonly IRepository<Crypto> _cryptoRepository;
        private readonly IMapper _mapper;

        public CryptoService(IRepository<Crypto> cryptoRepository, IMapper mapper)
        {
            _cryptoRepository = cryptoRepository;
            _mapper = mapper;
        }

        public async Task<AddCryptoDto> AddCrypto(AddCryptoDto addCryptoDto)
        {
            try
            {
                var cryptoToAdd = _mapper.Map<Crypto>(addCryptoDto);
                await _cryptoRepository.Add(cryptoToAdd);
                var cryptoDtoReturn = _mapper.Map<AddCryptoDto>(addCryptoDto);

                return cryptoDtoReturn;
            }
            catch (CryptoDataException ex)
            {
                throw new CryptoDataException(ex.Message);
            }
            catch (CryptoNotFoundException ex)
            {
                throw new CryptoNotFoundException(ex.Message);
            }

        }

        public async Task DeleteCryptoById(int id)
        {
            try
            {
                var cryptoToDelete = await _cryptoRepository.GetById(id);
                if (cryptoToDelete is null)
                {
                    new OurResponse($"The crypto with id: {id} could not be found");
                }

                await _cryptoRepository.Delete(cryptoToDelete);
            }
            catch (CryptoDataException ex)
            {
                throw new CryptoDataException(ex.Message);
            }
            catch (CryptoNotFoundException ex)
            {
                throw new CryptoNotFoundException(ex.Message);
            }
        }

        public async Task<List<CryptoDto>> GetAllCryptos()
        {
            try
            {
                var cryptos = await _cryptoRepository.GetAll();
                var cryptoDtos = _mapper.Map<List<CryptoDto>>(cryptos);
                return cryptoDtos;
            }
            catch (CryptoDataException ex)
            {
                throw new CryptoDataException(ex.Message);
            }
            catch (CryptoNotFoundException ex)
            {
                throw new CryptoNotFoundException(ex.Message);
            }
        }

        public async Task<CryptoDto> GetCryptoById(int id)
        {
            try
            {
                var crypto = await _cryptoRepository.GetById(id);
                if (crypto is null) { new OurResponse($"The crypto with id: {id} could not be found"); }
                var cryptoDto = _mapper.Map<CryptoDto>(crypto);
                return cryptoDto;
            }
            catch (CryptoDataException ex)
            {
                throw new CryptoDataException(ex.Message);
            }
            catch (CryptoNotFoundException ex)
            {
                throw new CryptoNotFoundException(ex.Message);
            }
        }

        public async Task<CryptoDto> UpdateCrypto(int id, UpdateCryptoDto updateCryptoDto)
        {
            try
            {
                var cryptoToUpdate = await _cryptoRepository.GetById(id);
                if (cryptoToUpdate is null) { new OurResponse($"The crypto with id: {id} could not be found"); }
                await _cryptoRepository.Update(cryptoToUpdate);
                var cryptoToUpdateDto = _mapper.Map<CryptoDto>(cryptoToUpdate);
                return cryptoToUpdateDto;
            }
            catch (CryptoDataException ex)
            {
                throw new CryptoDataException(ex.Message);
            }
            catch (CryptoNotFoundException ex)
            {
                throw new CryptoNotFoundException(ex.Message);
            }
        }
    }
}
