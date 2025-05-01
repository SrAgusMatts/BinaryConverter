using BinaryConverterAPI.Models;

namespace BinaryConverterAPI.Services
{
    public interface IBinaryService
    {
        Task<string> ConvertToAsciiAsync(BinaryRequest binary);
        Task<IEnumerable<BinaryConversion>> GetAllAsync();
    }

}
