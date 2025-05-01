using BinaryConverterAPI.Models;

namespace BinaryConverterAPI.Data.Interfaces
{
    public interface IUOW : IDisposable
    {
        IRepository<BinaryConversion> BinaryConversions { get; }
        Task<int> CompleteAsync();
    }

}
