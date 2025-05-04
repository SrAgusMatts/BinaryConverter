namespace BinaryConverterAPI.Models
{
    public class BinaryConversion
    {
        public int Id { get; set; }
        public string? BinaryInput { get; set; }
        public string? Result { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  
    }

}
