using BinaryConverterAPI.Models;

namespace BinaryConverterAPI.Services
{
    public class BinaryService
    {
        public string ConvertToAscii(BinaryRequest binary)
        {
            if (string.IsNullOrWhiteSpace(binary.BinaryInput) || binary.BinaryInput.Length != 8 || !binary.BinaryInput.All(c => c == '0' || c == '1'))
                return ("La cadena debe ser binaria y tener 8 dígitos.");

            try
            {
                int asciiCode = Convert.ToInt32(binary.BinaryInput);
                return asciiCode.ToString();
            }
            catch (Exception)
            {
                throw new Exception("Error al convertir");
            }
        }
    }
}
