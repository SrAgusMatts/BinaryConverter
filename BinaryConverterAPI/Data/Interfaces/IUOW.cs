using BinaryConverterAPI.Models;

namespace BinaryConverterAPI.Data.Interfaces
{
    public interface IUOW : IDisposable
    {
        IRepository<ConversionLetras> ConversionLetras { get; }
        void Complete();
    }

}
