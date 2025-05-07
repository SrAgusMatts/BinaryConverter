namespace BinaryConverterAPI.Models
{
    public class ConversorBinaria
    {
        public int Id { get; set; }
        public string? TextoEntrada { get; set; }
        public string? ResultadoBinario { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public string? ClaveUsadaLetra { get; set; }
        public string? Operador { get; set; }
        public string? ResultadoBinarioDeLaLetra { get; set; }
        public string? ResultadoEnFormatoLetra { get; set; }
    }

}
