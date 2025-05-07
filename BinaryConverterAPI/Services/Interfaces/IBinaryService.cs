using BinaryConverterAPI.Models;
using BinaryConverterAPI.Models.NewFolder;

namespace BinaryConverterAPI.Services
{
    public interface IBinaryService
    {
        IEnumerable<ConversionLetras> GetAll();
        PostResponse ConvertToAscii(BinaryRequest binary);
        DeleteResponse DeleteBinary(int id);
        BinaryResponseDTO GetById(int id);
        UpdateResponse UpdateBinary(BinaryRequest request, int id);
        PostResponse ConvertToAsciiLetter(LetterRequest request);
        IEnumerable<ConversorBinaria> GetAllLetter();
        DeleteResponse DeleteLetter(int id);
        LetterResponseDTO GetByIdLetter(int id);
        UpdateResponse UpdateLetter(LetterRequest request, int id);
    }

}
