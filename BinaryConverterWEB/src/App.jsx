import { useState } from 'react';
import BinaryForm from './config/BinaryForm';
import HistorialTable from './config/HistorialTable';

function App() {
  const [reload, setReload] = useState(false);

  const handleSuccess = () => {
    setReload(!reload); // Cambia estado para forzar refetch en tabla
  };

  return (
    <div className="container">
      <BinaryForm onConvertSuccess={handleSuccess} />
      <HistorialTable reloadTrigger={reload} />
    </div>
  );
}

export default App;
