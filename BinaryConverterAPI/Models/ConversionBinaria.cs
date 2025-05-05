namespace BinaryConverterAPI.Models
{
    public class ConversorBinaria
    {
        public int Id { get; set; }
        public string? TextoEntrada { get; set; }
        public string? ResultadoBinario { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;  
    }

}
