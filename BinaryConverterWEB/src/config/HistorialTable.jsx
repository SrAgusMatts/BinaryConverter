import { useEffect, useState } from 'react';
import { getConversionesLetras, deleteBinary } from '../assets/api';

const HistorialTable = ({ reloadTrigger, setReloadTrigger  }) => {
  const [historial, setHistorial] = useState([]);
  const [loading, setLoading] = useState(true);
  const [isModalUpdate, setIsModalUpdate] = useState(false);
  const [isModalDelete, setIsModalDelete] = useState(false);
  const [currentItem, setCurrentItem] = useState(null);
  const [newBinary, setNewBinary] = useState('');
  const [error, setError] = useState('');
  const [showToast, setShowToast] = useState(false);
  const [successMessage, setSuccessMessage] = useState('');

  useEffect(() => {
    const fetchHistorial = async () => {
      setLoading(true);
      try {
        const data = await getConversionesLetras();
        setHistorial(data);
      } catch (err) {
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    fetchHistorial();
  }, [reloadTrigger]);

  const handleDelete = async () => {
    setLoading(true);
    try {
      const data = await deleteBinary(currentItem);
      setSuccessMessage('Elemento eliminado correctamente.');
      setShowToast(true);
      setTimeout(() => setShowToast(false), 3000);
      setIsModalDelete(false);
      setReloadTrigger(Date.now());
    } catch (err) {
      setShowToast(true);
      setTimeout(() => setShowToast(false), 3000);
      setIsModalDelete(false);
    } finally {
      setLoading(false);
      setIsModalDelete(false);
    }
  };


  const openEditModal = (item) => {
    setCurrentItem(item);
    setNewBinary(item.binaryInput);
    setIsModalUpdate(true);
  };

  const openDeleteModal = (item) => {
    setCurrentItem(item);
    setNewBinary(item.binaryInput);
    setIsModalDelete(true);
  };

  const handleUpdate = () => {
    console.log('Actualizar ID:', currentItem.id, 'Nuevo valor:', newBinary);
    setSuccessMessage('Elemento modificado correctamente.');
    setShowToast(true);
    setTimeout(() => setShowToast(false), 3000);
    setIsModalUpdate(false);
    setReloadTrigger(Date.now());
  };


  if (loading) {
    return (
      <div className="container">
        <h2>Historial de conversiones</h2>
        <div className="spinner"></div>
      </div>
    );
  }

  if (!historial.length) {
    return (
      <div className="container">
        <h2>Historial de conversiones</h2>
        <p className="empty-message">No hay conversiones registradas aún.</p>
      </div>
    );
  }

  return (
    <div className="container">
      <h2>Historial de conversiones</h2>
      <table>
        <thead>
          <tr>
            <th>Binario</th>
            <th>ASCII</th>
            <th>Fecha</th>
            <th>Opciones</th>
          </tr>
        </thead>
        <tbody>
          {historial.map((item, index) => (
            <tr key={index}>
              <td>{item.binaryInput}</td>
              <td>{item.result}</td>
              <td>{new Date(item.createdAt).toLocaleString()}</td>
              <td>
                <button
                  className="btn-delete"
                  onClick={() => openDeleteModal(item.id)}
                >
                  Eliminar
                </button>
                <button
                  className="btn-edit"
                  onClick={() => openEditModal(item)}
                >
                  Modificar
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {isModalUpdate && (
        <div className="modal">
          <div className="modal-content">
            <h3>Modificar Binario</h3>
            <input
              type="text"
              value={newBinary}
              onChange={(e) => setNewBinary(e.target.value)}
              maxLength={8}
            />
            <div className="modal-buttons">
              <button onClick={handleUpdate}>Guardar</button>
              <button onClick={() => setIsModalUpdate(false)}>Cancelar</button>
            </div>
          </div>
        </div>
      )}

      {isModalDelete && (
        <div className="modal">
          <div className="modal-content">
            <h3>Eliminar Binario</h3>
            <p>
              ¿Estás seguro de que deseas eliminar el binario{" "}
              <strong>{currentItem?.binaryInput}</strong>?
            </p>
            <div className="modal-buttons">
              <button onClick={handleDelete}>Eliminar</button>
              <button onClick={() => setIsModalDelete(false)}>Cancelar</button>
            </div>
          </div>
        </div>
      )}

      {showToast && (
        <div className={`toast ${error ? 'toast-error' : 'toast-success'}`}>
          {error || successMessage}
        </div>
      )}

    </div>
  );
};




export default HistorialTable;
