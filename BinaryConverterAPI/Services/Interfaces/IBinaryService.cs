using BinaryConverterAPI.Models;

namespace BinaryConverterAPI.Services
{
    public interface IBinaryService
    {
        PostResponse ConvertToAscii(BinaryRequest binary);
        IEnumerable<ConversionLetras> GetAll();
    }

}
