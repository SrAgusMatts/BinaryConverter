import { useState } from 'react';
import BinaryForm from './config/BinaryForm';
import HistorialTable from './config/HistorialTable';
import './App.css';
import HistorialTableLetter from './config/HistorialTableLetter';
import LetterForm from './config/LetterForm';


function App() {
  const [reload, setReload] = useState(false);
  const [reloadTrigger, setReloadTrigger] = useState(Date.now());

  const handleSuccess = () => {
    setReload(!reload);
  };

  return (
    <div className="container">

      <div className="converter-section">

      <BinaryForm onConvertSuccess={handleSuccess} 
      reloadTrigger={reloadTrigger}
      setReloadTrigger={setReloadTrigger}
      />
      <HistorialTable
        reloadTrigger={reloadTrigger}
        setReloadTrigger={setReloadTrigger}
      />

      </div>
      
      <div className="converter-section">

      <LetterForm onConvertSuccess={handleSuccess} 
      reloadTrigger={reloadTrigger}
      setReloadTrigger={setReloadTrigger}
      />
      <HistorialTableLetter
        reloadTrigger={reloadTrigger}
        setReloadTrigger={setReloadTrigger}
      />

      </div>


    </div>
    
  );
}

export default App;
