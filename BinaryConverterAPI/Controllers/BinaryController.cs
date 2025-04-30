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
        [Route("convert")]
        public IActionResult ConvertBinary([FromBody] BinaryRequest request)
        {
            var binaryInputForm = _binaryService.ConvertToAscii(request);

            return Ok(new BinaryResponse { Character = binaryInputForm });
        }
    }
}
