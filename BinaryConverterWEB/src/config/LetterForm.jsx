import { useState } from 'react';
import { convertBinary, convertLetter } from '../assets/api';

const LetterForm = ({ onConvertSuccess, setReloadTrigger }) => {
  const [letter, setLetter] = useState('');
  const [clave, setClave] = useState('');
  const [operador, setOperador] = useState('XOR');
  const [ascii, setAscii] = useState('');
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);

  const handleConvert = async () => {
    setError('');
    setAscii('');
    setLoading(true);

    if (letter.length > 1) {
      setError('Ingrese solo un caracter');
      setLoading(false);
      return;
    }

    if (!/^[01]{8}$/.test(clave)) {
      setError('La clave binaria debe tener exactamente 8 dígitos (0 o 1).');
      setLoading(false);
      return;
    }

    try {
      const requestBody = {
        letterInput: letter,
        claveBinaria: clave,
        operador: operador
      };


      const data = await convertLetter(requestBody);
      setAscii(data.character || 'Conversión exitosa.');
      onConvertSuccess();
      setReloadTrigger(Date.now());
    } catch (err) {
      setError('No se pudo conectar al backend.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="container">
  <h2>Conversor Letra a Binario+ASCII</h2>

  <div className="converter-group">
    <input
      type="text"
      value={letter}
      onChange={(e) => setLetter(e.target.value)}
      placeholder="Ingrese un letra (1 caracter)"
      maxLength={8}
    />

    <input
      type="text"
      value={clave}
      onChange={(e) => setClave(e.target.value)}
      placeholder="Clave binaria (8 bits)"
      maxLength={8}
    />

    <select value={operador} onChange={(e) => setOperador(e.target.value)}>
      <option value="XOR">XOR</option>
      <option value="AND">AND</option>
      <option value="OR">OR</option>
    </select>

    <button className="convertir-btn" onClick={handleConvert} disabled={loading}>
      {loading ? 'Convirtiendo...' : 'Convertir'}
    </button>
  </div>

  {loading && <div className="spinner"></div>}
  {ascii && <p>Resultado: <strong>{ascii}</strong></p>}
  {error && <p className="error">{error}</p>}
</div>

  );
};

export default LetterForm;
