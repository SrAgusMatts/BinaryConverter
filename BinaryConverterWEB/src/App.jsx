import { useState } from 'react';
import './App.css';

function App() {
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
      const response = await fetch('https://localhost:50074/api/binary/convert', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ binary })
      });

      if (!response.ok) throw new Error('Error del servidor');

      const data = await response.json();
      setAscii(data.character);
    } catch (err) {
      setError('No se pudo conectar al backend.');
    }
  };

  return (
    <div className="container">
      <h1>Conversor Binario a ASCII</h1>
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
}

export default App;
