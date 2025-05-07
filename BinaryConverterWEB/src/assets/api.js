// src/api.js

const BASE_URL = import.meta.env.VITE_BASE_URL; // e.g. http://localhost:50074

//Conversion Binaria

export const convertBinary = async ({ binaryInput, claveBinaria, operador }) => {
  const response = await fetch(`${BASE_URL}/Binario/Binario-a-Letra`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({
      binaryInput,
      claveBinaria,
      operador
    })
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

export const deleteBinary = async (id) => {
  const response = await fetch(`${BASE_URL}/Binario/${id}`, {
    method: 'DELETE',
  });

  if (!response.ok) {
    throw new Error('Error al momento de borrar el binario');
  }

  return await response.json();
};

export const updateBinary = async (id, binaryRequest) => {
  const response = await fetch(`${BASE_URL}/Binario/Actualizar-Binario/${id}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      binaryInput: binaryRequest.binaryInput,
      claveBinaria: binaryRequest.claveBinaria,
      operador: binaryRequest.operador,
    }),
  });

  if (!response.ok) {
    throw new Error('Error al momento de actualizar el binario');
  }

  return await response.json();
};

//Conversion Letra

export const convertLetter = async ({ letterInput, claveBinaria, operador }) => {
  const response = await fetch(`${BASE_URL}/Binario/Letra-a-binario`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({
      letterInput,
      claveBinaria,
      operador
    })
  });

  if (!response.ok) {
    throw new Error('Error en la conversión');
  }

  return await response.json();
};


export const getConversionesBinarias = async () => {
  const response = await fetch(`${BASE_URL}/Binario/Historial-letras`);

  if (!response.ok) {
    throw new Error('Error al obtener el historial');
  }

  return await response.json();
};

export const deleteLetter = async (id) => {
  const response = await fetch(`${BASE_URL}/Binario/Eliminar-Letra/${id}`, {
    method: 'DELETE',
  });

  if (!response.ok) {
    throw new Error('Error al momento de borrar la letra');
  }

  return await response.json();
};

export const updateLetter = async (id, letterRequest) => {
  const response = await fetch(`${BASE_URL}/Binario/Actualizar-Letra/${id}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      letterInput: letterRequest.letterInput,
      claveBinaria: letterRequest.claveBinaria,
      operador: letterRequest.operador,
    }),
  });

  if (!response.ok) {
    throw new Error('Error al momento de actualizar la letra');
  }

  return await response.json();
};

