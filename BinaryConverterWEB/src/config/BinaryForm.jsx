import { useState } from 'react';
import { convertBinary } from '../assets/api';

const BinaryForm = ({ onConvertSuccess }) => {
  const [binary, setBinary] = useState('');
  const [ascii, setAscii] = useState('');
  const [error, setError] = useState('');

  const handleConvert = async () => {
    setError('');
    setAscii('');

    if (!/^[01]{8}$/.test(binary)) {
      setError('Ingresa exactamente 8 dígitos binarios (0 o 1).');
      return;
    }

    try {
      const data = await convertBinary(binary);
      setAscii(data.character);
      onConvertSuccess(); // Actualiza el historial desde App
    } catch (err) {
      setError('No se pudo conectar al backend.');
    }
  };

  return (
    <div className="container">
      <h2>Conversor Binario a ASCII</h2>
      <input
        type="text"
        value={binary}
        onChange={(e) => setBinary(e.target.value)}
        placeholder="Ej: 01100001"
      />
      <button onClick={handleConvert}>Convertir</button>
      {ascii && <p>Resultado: <strong>{ascii}</strong></p>}
      {error && <p className="error">{error}</p>}
    </div>
  );
};

export default BinaryForm;
