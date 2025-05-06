using Microsoft.AspNetCore.Mvc;
using BinaryConverterAPI.Services;
using BinaryConverterAPI.Models;
using BinaryConverterAPI.Data;

namespace BinaryConverterAPI.Controllers
{
    [ApiController]
    [Route("Binario")]
    public class BinaryController : ControllerBase
    {
        #region Private
        private readonly AppDbContext _context;
        private readonly BinaryService _binaryService;
        #endregion

        #region Injeccion
        public BinaryController(BinaryService binaryService, AppDbContext context)
        {
            _binaryService = binaryService;
            _context = context;
        }
        #endregion

        #region Entrada binaria y salida letra

        [HttpPost]
        [Route("Binario-a-Letra")]
        public IActionResult ConvertBinary([FromBody] BinaryRequest request)
        {
                PostResponse response = _binaryService.ConvertToAscii(request);
                return Ok(response);  
        }

        [HttpGet]
        [Route("Conversiones")]
        public IActionResult GetAllConversions()
        {
            var list = _binaryService.GetAll();
            return Ok(list.ToList());
        }

        [HttpDelete]
        [Route("Borrar-Binario/{id}")]
        public IActionResult DeleteBinary(int id)
        {
            DeleteResponse response = _binaryService.DeleteBinary(id);
            return Ok(response);
        }

        #endregion

        #region Entrada Letra y salida Binaria

        [HttpPost]
        [Route("Letra-a-binario")]
        public IActionResult ConvertLetter([FromBody] BinaryRequest request)
        {
            PostResponse response = _binaryService.ConvertToAscii(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("Historial-binario")]
        public IActionResult GetHistoryBinary()
        {
            var history = _binaryService.GetAll();
            return Ok(history);
        }

        #endregion
    }
}
