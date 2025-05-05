// src/api.js

const BASE_URL = import.meta.env.VITE_BASE_URL; // e.g. http://localhost:50074

export const convertBinary = async (binary) => {
  const response = await fetch(`${BASE_URL}/Binario/Binario-a-Letra`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({ binaryInput: binary })
  });

  if (!response.ok) {
    throw new Error('Error en la conversión');
  }

  return await response.json();
};

export const getConversionesLetras = async () => {
  const response = await fetch(`${BASE_URL}/Binario/Conversiones`);

  if (!response.ok) {
    throw new Error('Error al obtener el historial');
  }

  return await response.json();
};
