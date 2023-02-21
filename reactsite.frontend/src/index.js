import React from 'react';
import ReactDOM from 'react-dom/client';
import Main from './Main';
import 'bootstrap/dist/css/bootstrap.min.css';
import $ from 'jquery';
import Popper from 'popper.js';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import {BrowserRouter, Route, Router, Routes} from "react-router-dom";
import Navbar from "./Components/Navbar";
import Users from "./Components/Users";
import "@progress/kendo-theme-material/dist/all.css";
import "hammerjs";




const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        <BrowserRouter>
      <Main/>
        </BrowserRouter>
    </React.StrictMode>
);


