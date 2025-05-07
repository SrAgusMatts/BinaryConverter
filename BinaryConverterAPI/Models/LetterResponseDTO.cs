namespace BinaryConverterAPI.Models
{
    public class LetterResponseDTO
    {
        public int Id { get; set; }
        public string? Letra { get; set; }
        public string? ValorBinario { get; set; }
        public string? ResultadoEnLetra { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
