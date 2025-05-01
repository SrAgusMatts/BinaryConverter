using BinaryConverterAPI.Data.Interfaces;
using BinaryConverterAPI.Models;

namespace BinaryConverterAPI.Data.Repositories
{
    public class UOW : IUOW
    {
        private readonly AppDbContext _context;

        public IRepository<BinaryConversion> BinaryConversions { get; }

        public UOW(AppDbContext context)
        {
            _context = context;
            BinaryConversions = new Repository<BinaryConversion>(context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
