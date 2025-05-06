import { useState } from 'react';
import { convertBinary } from '../assets/api';

const BinaryForm = ({ onConvertSuccess, setReloadTrigger }) => {
  const [binary, setBinary] = useState('');
  const [ascii, setAscii] = useState('');
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);

  const handleConvert = async () => {
    setError('');
    setAscii('');
    setLoading(true);

    if (!/^[01]{8}$/.test(binary)) {
      setError('Ingresa exactamente 8 dígitos binarios (0 o 1).');
      setLoading(false);
      return;
    }

    try {
      const data = await convertBinary(binary);
      setAscii(data.character);
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
      <h2>Conversor Binario a ASCII</h2>
      <input
        type="text"
        value={binary}
        onChange={(e) => setBinary(e.target.value)}
        placeholder="Ingrese una clave en binario.."
      />
      <button onClick={handleConvert} disabled={loading}>
        {loading ? 'Convirtiendo...' : 'Convertir'}
      </button>
      {loading && <div className="spinner"></div>}
      {ascii && <p>Resultado: <strong>{ascii}</strong></p>}
      {error && <p className="error">{error}</p>}
    </div>
  );
};

export default BinaryForm;
