using BinaryConverterAPI.Data.Interfaces;
using BinaryConverterAPI.Models;

namespace BinaryConverterAPI.Services
{
    public class BinaryService : IBinaryService
    {
        private readonly IUOW _unitOfWork;

        public BinaryService(IUOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> ConvertToAsciiAsync(BinaryRequest binary)
        {
            if (string.IsNullOrWhiteSpace(binary.BinaryInput) || binary.BinaryInput.Length != 8 || !binary.BinaryInput.All(c => c == '0' || c == '1'))
                return "La cadena debe ser binaria y tener 8 dígitos.";

            try
            {
                int asciiCode = Convert.ToInt32(binary.BinaryInput, 2);
                char character = (char)asciiCode;
                string result = character.ToString();

                var conversion = new BinaryConversion
                {
                    BinaryInput = binary.BinaryInput,
                    Result = result
                };

                await _unitOfWork.BinaryConversions.AddAsync(conversion);
                await _unitOfWork.CompleteAsync();

                return result;
            }
            catch (Exception)
            {
                throw new Exception("Error al convertir");
            }
        }

        public async Task<IEnumerable<BinaryConversion>> GetAllAsync()
        {
            return await _unitOfWork.BinaryConversions.GetAllAsync();
        }
    }

}
