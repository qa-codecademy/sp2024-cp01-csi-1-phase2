using FenixCoin.Dto.CryptoDTO;
using FenixCoin.Services.Interfaces;
using FenixCoin.Shared.CryptoExceptions;
using Microsoft.AspNetCore.Mvc;

namespace FenixCoin.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoService _cryptoService;

        public CryptoController(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        [HttpPost("addCrypto")]
        public async Task<IActionResult> AddNewCrypto([FromBody] AddCryptoDto addCryptoDto)
        {
            try
            {
                await _cryptoService.AddCrypto(addCryptoDto);
                return StatusCode(StatusCodes.Status201Created, "Crypto Added");
            }
            catch (CryptoDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CryptoNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCrypto(int id)
        {
            try
            {
                await _cryptoService.DeleteCryptoById(id);
                return Ok("Crypto Deleted!!!");
            }
            catch (CryptoDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CryptoNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CryptoDto>> GetCryptoById(int id)
        {
            try
            {
                var crypto = await _cryptoService.GetCryptoById(id);
                return Ok(crypto);
            }
            catch (CryptoDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CryptoNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("getAllCryptos")]

        public async Task<IActionResult> GetAllCryptos()
        {
            try
            {
                var cryptoDb = await _cryptoService.GetAllCryptos();
                return Ok(cryptoDb);
            }
            catch (CryptoDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CryptoNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //[HttpPut("{id}")]

        //public async Task<IActionResult> UpdateCrypto(int id, [FromBody] UpdateCryptoDto updateCryptoDto)
        //{
        //try
        //{
        //var crypto = await _cryptoService.UpdateCrypto(id, updateCryptoDto);
        //return Ok($"Crypto {updateCryptoDto.CryptoName} has received changes");
        //}
        //catch (CryptoDataException ex)
        //{
        //return BadRequest(ex.Message);
        //}
        //catch (CryptoNotFoundException ex)
        //{
        //return NotFound(ex.Message);
        //}
        //catch (Exception ex)
        //{
        //return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //}

    }
}


