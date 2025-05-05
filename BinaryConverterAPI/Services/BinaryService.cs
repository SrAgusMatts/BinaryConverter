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

        public PostResponse ConvertToAscii(BinaryRequest binary)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(binary.BinaryInput) ||
                binary.BinaryInput.Length != 8 ||
                !binary.BinaryInput.All(c => c == '0' || c == '1'))
                {
                    throw new Exception("La cadena debe ser binaria y tener 8 dígitos.");
                }

                int asciiCode = Convert.ToInt32(binary.BinaryInput, 2);
                char character = (char)asciiCode;

                var conversion = new ConversionLetras
                {
                    BinaryInput = binary.BinaryInput,
                    Result = character.ToString()
                };

                _unitOfWork.ConversionLetras.Add(conversion);
                _unitOfWork.Complete();

                return new PostResponse { Id = conversion.Id };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public IEnumerable<ConversionLetras> GetAll()
        {
            return _unitOfWork.ConversionLetras.GetAll();
        }
    }


}
