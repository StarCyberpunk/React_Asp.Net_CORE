import React from 'react';
import {Link, NavLink} from "react-router-dom";
import {useDispatch, useSelector} from "react-redux";
import Cookies from "js-cookie";




function MainPage() {
    const dispatch=useDispatch();
    const id=useSelector(state => state.reducerUser.access_token)
    console.log(id);
    const flag=Cookies.get('flag')
    console.log(flag)


    return (

        <div className='MainPage'>
            <div className="container">
                <h2>Данный сайт посвящен выполнению задач(Работает только с включенным сервером)
                </h2>
                <img src="https://stihi.ru/pics/2020/02/19/8869.jpg"/>
            </div>
        </div>
    );
}
export default MainPage;