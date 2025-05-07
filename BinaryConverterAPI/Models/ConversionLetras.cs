namespace BinaryConverterAPI.Models
{
    public class ConversionLetras
    {
        public int Id { get; set; }
        public string? BinaryInput { get; set; }
        public string? Result { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? ClaveUsada { get; set; }
        public string? Operador { get; set; }
        public string? ResultadoBinario { get; set; }
    }
}
