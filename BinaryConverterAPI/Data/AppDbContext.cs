using Microsoft.EntityFrameworkCore;
using BinaryConverterAPI.Models;

namespace BinaryConverterAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BinaryConversion> Conversions => Set<BinaryConversion>();
    }
}
