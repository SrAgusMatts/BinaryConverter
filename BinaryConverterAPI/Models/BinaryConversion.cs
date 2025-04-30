namespace BinaryConverterAPI.Models
{
    public class BinaryConversion
    {
        public int Id { get; set; }
        public string Binary { get; set; } = string.Empty;
        public string Character { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
