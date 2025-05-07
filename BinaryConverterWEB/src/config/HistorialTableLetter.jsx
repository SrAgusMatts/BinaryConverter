import { useEffect, useState } from 'react';
import { getConversionesBinarias, deleteLetter, updateLetter } from '../assets/api';

const HistorialTableLetter = ({ reloadTrigger, setReloadTrigger  }) => {
  const [historial, setHistorial] = useState([]);
  const [loading, setLoading] = useState(true);
  const [isModalUpdate, setIsModalUpdate] = useState(false);
  const [isModalDelete, setIsModalDelete] = useState(false);
  const [currentItem, setCurrentItem] = useState(null);
  const [newLetter, setNewLetter] = useState('');
  const [error, setError] = useState('');
  const [showToast, setShowToast] = useState(false);
  const [successMessage, setSuccessMessage] = useState('');

  useEffect(() => {
    const fetchHistorial = async () => {
      setLoading(true);
      try {
        const data = await getConversionesBinarias();
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
      const data = await deleteLetter(currentItem);
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
    setNewLetter(item.letterInput);
    setIsModalUpdate(true);
  };

  const openDeleteModal = (item) => {
    setCurrentItem(item);
    setNewLetter(item.letterInput);
    setIsModalDelete(true);
  };

  const handleUpdate = async () => {
      
    try {

      const dataToUpdate = {
        letterInput: newLetter,     
        claveBinaria: currentItem.claveUsadaLetra,      // ¡coincide con ClaveBinaria!
        operador: currentItem.operador,       // ¡igual!
      };

      const data = await updateLetter(currentItem.id, dataToUpdate);
      setSuccessMessage('Elemento actualizado correctamente.');
      setShowToast(true);
      setTimeout(() => setShowToast(false), 3000);
      setIsModalUpdate(false);
      setReloadTrigger(Date.now());
    } catch (err) {
      setShowToast(true);
      setTimeout(() => setShowToast(false), 3000);
      setIsModalUpdate(false);
    } finally {
      setLoading(false);
      setIsModalUpdate(false);
    }
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
    <div className="table-wrapper">
      <h2>Historial de conversiones</h2>
      <table>
      <thead>
        <tr>
          <th>Letra</th>
          <th>Binario</th>
          <th>Clave</th>
          <th>Operador</th>
          <th>Cifrado Binario</th>
          <th>ASCII</th>
          <th>Opciones</th>
        </tr>
      </thead>

        <tbody>
          {historial.map((item, index) => (
            <tr key={index}>
              <td>{item.textoEntrada}</td>
              <td>{item.resultadoBinario}</td>
              <td>{item.claveUsadaLetra}</td>
              <td>{item.operador}</td>
              <td>{item.resultadoBinario}</td>
              <td>{item.resultadoEnFormatoLetra}</td>
              <td  class="table-buttons">
                <button className="btn-delete" onClick={() => openDeleteModal(item.id)}>Eliminar</button>
                <button className="btn-edit" onClick={() => openEditModal(item)}>Modificar</button>
              </td>
            </tr>
          ))}
        </tbody>

      </table>

      {isModalUpdate && (
        <div className="modal">
          <div className="modal-content">
            <h3>Modificar Letra</h3>
            <input
              type="text"
              value={newLetter}
              onChange={(e) => setNewLetter(e.target.value)}
              placeholder="Nueva Letra"
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
              <strong>{currentItem?.letterInput}</strong>?
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




export default HistorialTableLetter;
