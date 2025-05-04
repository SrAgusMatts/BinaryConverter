using Microsoft.AspNetCore.Mvc;
using BinaryConverterAPI.Services;
using BinaryConverterAPI.Models;
using BinaryConverterAPI.Data;

namespace BinaryConverterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BinaryController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly BinaryService _binaryService;

        public BinaryController(BinaryService binaryService, AppDbContext context)
        {
            _binaryService = binaryService;
            _context = context;
        }

        [HttpPost]
        [Route("Binario-a-Letra")]
        public async Task<IActionResult> ConvertBinary([FromBody] BinaryRequest request)
        {
            var result = await _binaryService.ConvertToAsciiAsync(request);
            return Ok(new BinaryResponse { Character = result });
        }

        [HttpGet]
        [Route("Historial")]
        public async Task<IActionResult> GetHistory()
        {
            var history = await _binaryService.GetAllAsync();
            return Ok(history);
        } 

    }
}
