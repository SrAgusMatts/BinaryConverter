using BinaryConverterAPI.Models;

namespace BinaryConverterAPI.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        ConversionLetras GetById(int id);
        void Delete(ConversionLetras entity);
    }

}
