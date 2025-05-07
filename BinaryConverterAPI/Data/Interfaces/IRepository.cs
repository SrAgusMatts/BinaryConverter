using BinaryConverterAPI.Models;

namespace BinaryConverterAPI.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        ConversionLetras GetById(int id);
        void Delete(ConversionLetras entity);
        void Update(ConversionLetras entity);

        IEnumerable<T> GetAllLetter();
        void AddLetter(T entity);
        ConversorBinaria GetByIdLetter(int id);
        void DeleteLetter(ConversorBinaria entity);
        void UpdateLetter(ConversorBinaria entity);
    }

}
