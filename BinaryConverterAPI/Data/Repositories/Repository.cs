using BinaryConverterAPI.Data.Interfaces;
using BinaryConverterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BinaryConverterAPI.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public ConversionLetras GetById(int id)
        {
            return _context.ConversionLetras.Find(id);
        }

        public void Delete(ConversionLetras entity)
        {
            _context.ConversionLetras.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }

}
