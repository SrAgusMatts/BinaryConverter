using BinaryConverterAPI.Data.Interfaces;
using BinaryConverterAPI.Models;

namespace BinaryConverterAPI.Data.Repositories
{
    public class UOW : IUOW
    {
        private readonly AppDbContext _context;

        public IRepository<ConversionLetras> ConversionLetras { get; }

        public UOW(AppDbContext context)
        {
            _context = context;
            ConversionLetras = new Repository<ConversionLetras>(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
