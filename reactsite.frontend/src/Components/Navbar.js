import React from 'react';
import {Link, NavLink} from "react-router-dom";
import Cookies from "js-cookie";
import {useSelector} from "react-redux";


/*Надо обновлять*/

function Navbar() {
    const stateflag=useSelector(state => state.reducerUser)
   const flag= Cookies.get('flag')
    console.log(flag)
    if(flag==='true'){
        return <div className='Navbar ' className="p-3 mb-2 bg-black text-white">

            <ul className="nav nav-tabs">
                <div className="col-5">
                    <h2>DOGLNOW</h2>
                </div>

                <li className="nav-item">
                    <NavLink className="nav-link " aria-current="page" to='/'>Главная</NavLink>
                </li>

                <li className="nav-item">
                    <NavLink className="nav-link disabled" to='/users'>Друзья</NavLink>
                </li>


                <li className="nav-item dropdown">
                    <a className="nav-link dropdown-toggle" data-bs-toggle="dropdown" href="#" role="button"
                       aria-expanded="false">Активность</a>
                    <ul className="dropdown-menu">
                        <li className="nav-item"><NavLink className="dropdown-item" to='/dailytasks'>Мой день</NavLink>
                        </li>
                        <li className="nav-item"><NavLink className="dropdown-item" to='/weeklytasks'>Моя неделя</NavLink>
                        </li>
                        <li className="nav-item"><NavLink className="dropdown-item" to='/addplan'>Составить план</NavLink>
                        </li>
                    </ul>
                </li>



                        <li className="nav-item dropdown">
                            <a className="nav-link dropdown-toggle" data-bs-toggle="dropdown" href="#" role="button"
                               aria-expanded="false">{stateflag.login}</a>
                            <ul className="dropdown-menu">
                                <li className="nav-item"><NavLink className="dropdown-item" to='/signup'>Аккаунт</NavLink>
                                </li>
                                <li className="nav-item"><NavLink className="dropdown-item" to='/logout'>Выйти</NavLink>
                                </li>
                            </ul>
                        </li>


            </ul>
        </div>
    }
    else {
        return <div className='Navbar ' className="p-3 mb-2 bg-black text-white">

            <ul className="nav nav-tabs">
                <div className="col-5">
                    <h2>Название</h2>
                </div>

                <li className="nav-item">
                    <NavLink className="nav-link " aria-current="page" to='/'>Главная</NavLink>
                </li>

                <li className="nav-item">
                    <NavLink className="nav-link disabled" to='/users'>Друзья</NavLink>
                </li>


                    <li className="nav-item">
                        <NavLink className="nav-link disabled" to='/dailytasks'>Мой день</NavLink>
                    </li>



                    <li className="nav-item">
                        <NavLink className="nav-link" to='/signup'>Войти</NavLink>
                    </li>


                {/*<li className="nav-item">
                    <a className="nav-link disabled">Отключенная</a>
                </li>*/}
                {/*
                 <li className="nav-item">
                        <NavLink className="nav-link" to='/signup'>Аккаунт</NavLink>
                    </li>
                <li className="nav-item dropdown">
                    <a className="nav-link dropdown-toggle" data-bs-toggle="dropdown" href="#" role="button"
                       aria-expanded="false">Выпадающий список</a>
                    <ul className="dropdown-menu">
                        <li><a className="dropdown-item" href="#">Действие</a></li>
                        <li><a className="dropdown-item" href="#">Другое действие</a></li>
                        <li><a className="dropdown-item" href="#">Что-то еще здесь</a></li>
                        <li>
                            <hr className="dropdown-divider"/>
                        </li>
                        <li><a className="dropdown-item" href="#">Отделенная ссылка</a></li>
                    </ul>
                </li>*/}
            </ul>
        </div>
    }
}
export default Navbar;