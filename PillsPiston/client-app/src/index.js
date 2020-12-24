import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import {BrowserRouter} from 'react-router-dom';
import 'bootstrap/dist/js/bootstrap.bundle';
import 'bootstrap/dist/css/bootstrap.css';

const application =(
  <BrowserRouter>
    <App />
  </BrowserRouter>
)

ReactDOM.render(
  <>
    {application}
  </>,
  document.getElementById('root')
);

reportWebVitals();
