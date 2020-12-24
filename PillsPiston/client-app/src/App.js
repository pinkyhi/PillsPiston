import React from 'react'
import './App.css';
import AppSettings from './AppSettings';
import AppContext, {useDefaultValue} from './contexts/appContext';
import Layout from './hoc/Layout/Layout'
function App() {
  // I really don't know what to do with this interceptor
  return (
    <AppContext.Provider value={useDefaultValue()}>
      <AppSettings/>
      <Layout>
      </Layout>
    </AppContext.Provider>
  );
}

export default App;
