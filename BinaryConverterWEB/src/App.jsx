import { useState } from 'react';
import BinaryForm from './config/BinaryForm';
import HistorialTable from './config/HistorialTable';
import './app.css';


function App() {
  const [reload, setReload] = useState(false);
  const [reloadTrigger, setReloadTrigger] = useState(Date.now());

  const handleSuccess = () => {
    setReload(!reload);
  };

  return (
    <div className="container">
      <BinaryForm onConvertSuccess={handleSuccess} 
      reloadTrigger={reloadTrigger}
      setReloadTrigger={setReloadTrigger}
      />
      <HistorialTable
        reloadTrigger={reloadTrigger}
        setReloadTrigger={setReloadTrigger}
      />
    </div>
  );
}

export default App;
