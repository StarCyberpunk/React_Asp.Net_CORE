import React from 'react';
import Users from './Components/Users';
import Navbar from "./Components/Navbar";
import {BrowserRouter, Route, Router, Link, NavLink, Routes} from 'react-router-dom';
import MainPage from "./Components/MainPage";
import DailyTasks from "./Components/TASKS/DailyTasks";
import SignUp from "./Components/Account/SignUp";
import LogOut from "./Components/Account/LogOut";
import WeeklyTasks from "./Components/TASKS/WeeklyTasks";



function Main() {

    return (

        <div className='Main'>
            <Navbar/>

            <Routes>
                <Route path="/" element={<MainPage />}/>
                <Route path="/users" element={<Users/>}/>
                <Route path="/dailytasks" element={<DailyTasks/>}/>
                <Route path="/signup" element={<SignUp/>}/>
                <Route path="/logout" element={<LogOut/>}/>
                <Route path="/weeklytasks" element={<WeeklyTasks/>}/>
            </Routes>
        </div>
        );
}
export default Main;


