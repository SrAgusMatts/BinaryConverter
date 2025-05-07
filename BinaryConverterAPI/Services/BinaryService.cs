using BinaryConverterAPI.Data.Interfaces;
using BinaryConverterAPI.Models;
using BinaryConverterAPI.Models.NewFolder;

namespace BinaryConverterAPI.Services
{
    public class BinaryService : IBinaryService
    {
        private readonly IUOW _unitOfWork;

        public BinaryService(IUOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PostResponse ConvertToAscii(BinaryRequest binary)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(binary.BinaryInput) ||
                    binary.BinaryInput.Length != 8 ||
                    !binary.BinaryInput.All(c => c == '0' || c == '1'))
                {
                    throw new Exception("La cadena debe ser binaria y tener 8 dígitos.");
                }

                if (string.IsNullOrWhiteSpace(binary.ClaveBinaria) ||
                    binary.ClaveBinaria.Length != 8 ||
                    !binary.ClaveBinaria.All(c => c == '0' || c == '1'))
                {
                    throw new Exception("La clave debe ser binaria y tener 8 dígitos.");
                }

                string resultadoBinario = AplicarOperacionLogica(binary.BinaryInput, binary.ClaveBinaria, binary.Operador);

                int asciiCode = Convert.ToInt32(resultadoBinario, 2);
                char character = (char)asciiCode;

                var conversion = new ConversionLetras
                {
                    BinaryInput = binary.BinaryInput,
                    Result = character.ToString(),
                    ClaveUsada = binary.ClaveBinaria,
                    Operador = binary.Operador,
                    ResultadoBinario = resultadoBinario
                };

                _unitOfWork.ConversionLetras.Add(conversion);
                _unitOfWork.Complete();

                return new PostResponse { Id = conversion.Id };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string AplicarOperacionLogica(string binario, string clave, string operador)
        {
            char[] resultado = new char[8];

            for (int i = 0; i < 8; i++)
            {
                char b = binario[i];
                char k = clave[i];

                resultado[i] = operador.ToUpper() switch
                {
                    "XOR" => b == k ? '0' : '1',
                    "AND" => (b == '1' && k == '1') ? '1' : '0',
                    "OR" => (b == '1' || k == '1') ? '1' : '0',
                    _ => throw new Exception("Operador lógico no válido.")
                };
            }

            return new string(resultado);
        }


        public IEnumerable<ConversionLetras> GetAll()
        {
            return _unitOfWork.ConversionLetras.GetAll();
        }

        public BinaryResponseDTO GetById(int id)
        {
            try
            {
                var result = _unitOfWork.ConversionLetras.GetById(id);

                BinaryResponseDTO binaryResponseDTO = new BinaryResponseDTO { 
                
                    Id = result.Id,
                    ValorBinario = result.BinaryInput,
                    ResultadoEnLetra = result.Result,
                    FechaCreacion = result.CreatedAt

                };

                return binaryResponseDTO;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public UpdateResponse UpdateBinary(BinaryRequest request, int id)
        {
            try
            {

                string resultadoBinario = AplicarOperacionLogica(request.BinaryInput, request.ClaveBinaria, request.Operador);

                int asciiCode = Convert.ToInt32(resultadoBinario, 2);
                char character = (char)asciiCode;

                var result = _unitOfWork.ConversionLetras.GetById(id);


                result.BinaryInput = request.BinaryInput;
                result.ClaveUsada = request.ClaveBinaria;
                result.Operador = request.Operador;
                result.Result = character.ToString();

                _unitOfWork.ConversionLetras.Update(result);
                _unitOfWork.Complete();

                return new UpdateResponse { Message = "Se ha actualizado exitosamente" };

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }



        public DeleteResponse DeleteBinary(int id)
        {
            try
            {

                var result = _unitOfWork.ConversionLetras.GetById(id);

                _unitOfWork.ConversionLetras.Delete(result);
                _unitOfWork.Complete();

                return new DeleteResponse { Message = "Se ha eliminado exitosamente" };

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        //Conversion Letras

        public PostResponse ConvertToAsciiLetter(LetterRequest request)
        {
            if (string.IsNullOrEmpty(request.LetterInput) || request.LetterInput.Length != 1)
            {
                throw new ArgumentException("Debe ingresar una sola letra.");
            }

            char letter = request.LetterInput[0];
            string binary = Convert.ToString(letter, 2).PadLeft(8, '0');

            string resultadoBinario = AplicarOperacionLogica(binary, request.ClaveBinaria, request.Operador);

            int asciiCodeletter = Convert.ToInt32(resultadoBinario, 2);
            char characterletter = (char)asciiCodeletter;

            var conversion = new ConversorBinaria
            {
                TextoEntrada = request.LetterInput,
                ResultadoBinario = binary,
                Operador = request.Operador,
                ClaveUsadaLetra = request.ClaveBinaria,
                ResultadoBinarioDeLaLetra = AplicarOperacionLogica(binary, request.ClaveBinaria, request.Operador),
                ResultadoEnFormatoLetra = characterletter.ToString()
            };

            _unitOfWork.ConversionBinaria.AddLetter(conversion);
            _unitOfWork.Complete();

            return new PostResponse { Id = conversion.Id};
        }

        public UpdateResponse UpdateLetter(LetterRequest request, int id)
        {
            var entity = _unitOfWork.ConversionBinaria.GetByIdLetter(id);
            if (entity == null)
            {
                throw new Exception("No se encontró el registro.");
            }

            char letter = request.LetterInput[0];
            string binary = Convert.ToString(letter, 2).PadLeft(8, '0');

            string resultadoBinario = AplicarOperacionLogica(binary, request.ClaveBinaria, request.Operador);

            int asciiCodeletter = Convert.ToInt32(resultadoBinario, 2);
            char characterletter = (char)asciiCodeletter;

            entity.TextoEntrada = request.LetterInput;
            entity.ClaveUsadaLetra = request.ClaveBinaria;
            entity.Operador = request.Operador;
            entity.ResultadoBinario = AplicarOperacion(binary, request.ClaveBinaria, request.Operador);
            entity.ResultadoBinarioDeLaLetra = Convert.ToChar(Convert.ToByte(entity.ResultadoBinario, 2)).ToString();
            entity.ResultadoEnFormatoLetra = characterletter.ToString();

            _unitOfWork.ConversionBinaria.UpdateLetter(entity);
            _unitOfWork.Complete();

            return new UpdateResponse { Message = "Actualización exitosa" };
        }

        public DeleteResponse DeleteLetter(int id)
        {
            var entity = _unitOfWork.ConversionBinaria.GetByIdLetter(id);
            if (entity == null)
            {
                throw new Exception("No se encontró el registro.");
            }

            _unitOfWork.ConversionBinaria.DeleteLetter(entity);
            _unitOfWork.Complete();

            return new DeleteResponse { Message = "Eliminado exitosamente" };
        }

        private string AplicarOperacion(string binario, string clave, string operador)
        {
            var result = new char[8];
            for (int i = 0; i < 8; i++)
            {
                result[i] = operador switch
                {
                    "XOR" => binario[i] == clave[i] ? '0' : '1',
                    "AND" => binario[i] == '1' && clave[i] == '1' ? '1' : '0',
                    "OR" => binario[i] == '1' || clave[i] == '1' ? '1' : '0',
                    _ => throw new ArgumentException("Operador inválido")
                };
            }
            return new string(result);
        }

        public IEnumerable<ConversorBinaria> GetAllLetter()
        {
            return _unitOfWork.ConversionBinaria.GetAllLetter();
        }

        public LetterResponseDTO GetByIdLetter(int id)
        {
            var item = _unitOfWork.ConversionBinaria.GetByIdLetter(id);
            if (item == null)
            {
                throw new Exception("No encontrado.");
            }

            return new LetterResponseDTO
            {
                Id = item.Id,
                Letra = item.TextoEntrada,
                ValorBinario = item.ResultadoBinario,
                FechaCreacion = item.FechaCreacion
                
            };
        }
    }
}
