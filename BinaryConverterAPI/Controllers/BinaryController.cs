using Microsoft.AspNetCore.Mvc;
using BinaryConverterAPI.Services;
using BinaryConverterAPI.Models;
using BinaryConverterAPI.Data;
using BinaryConverterAPI.Models.NewFolder;

namespace BinaryConverterAPI.Controllers
{
    [ApiController]
    [Route("Binario")]
    public class BinaryController : ControllerBase
    {
        #region Private
        private readonly AppDbContext _context;
        private readonly IBinaryService _binaryService;
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
            var response = _binaryService.GetAll();
            return Ok(response.ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            BinaryResponseDTO response = _binaryService.GetById(id);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBinary(int id)
        {
            DeleteResponse response = _binaryService.DeleteBinary(id);
            return Ok(response);
        }

        [HttpPut]
        [Route("Actualizar-Binario/{id}")]
        public IActionResult UpdateBinary(int id, [FromBody] BinaryRequest request)
        {
            UpdateResponse response = _binaryService.UpdateBinary(request, id);
            return Ok(response);
        }

        #endregion

        #region Entrada Letra y salida Binaria

        [HttpPost]
        [Route("Letra-a-binario")]
        public IActionResult ConvertLetter([FromBody] LetterRequest request)
        {
            PostResponse response = _binaryService.ConvertToAsciiLetter(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("Historial-letras")]
        public IActionResult GetHistoryLetter()
        {
            var history = _binaryService.GetAllLetter();
            return Ok(history);
        }

        [HttpGet]
        [Route("IdLetra/{id}")]
        public IActionResult GetByIdLetter(int id)
        {
            LetterResponseDTO response = _binaryService.GetByIdLetter(id);
            return Ok(response);
        }

        [HttpDelete]
        [Route("Eliminar-Letra/{id}")]
        public IActionResult DeleteLetter(int id)
        {
            DeleteResponse response = _binaryService.DeleteLetter(id);
            return Ok(response);
        }

        [HttpPut]
        [Route("Actualizar-Letra/{id}")]
        public IActionResult UpdateLetter(int id, [FromBody] LetterRequest request)
        {
            UpdateResponse response = _binaryService.UpdateLetter(request, id);
            return Ok(response);
        }

        #endregion
    }
}
