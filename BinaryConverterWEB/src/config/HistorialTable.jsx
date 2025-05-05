import { useEffect, useState } from 'react';
import { getConversionesLetras } from '../assets/api';

const HistorialTable = ({ reloadTrigger }) => {
  const [historial, setHistorial] = useState([]);

  useEffect(() => {
    const fetchHistorial = async () => {
      try {
        const data = await getConversionesLetras();
        setHistorial(data);
      } catch (err) {
        console.error(err);
      }
    };

    fetchHistorial();
  }, [reloadTrigger]);

  if (!historial.length) return null;

  return (
    <div className="container">
      <h2>Historial de conversiones</h2>
      <table>
        <thead>
          <tr>
            <th>Binario</th>
            <th>ASCII</th>
            <th>Fecha</th>
          </tr>
        </thead>
        <tbody>
          {historial.map((item, index) => (
            <tr key={index}>
              <td>{item.binaryInput}</td>
              <td>{item.result}</td>
              <td>{new Date(item.createdAt).toLocaleString()}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default HistorialTable;
