import React from 'react';
import {Link, NavLink} from "react-router-dom";




function Navbar() {
    return (
        <div className='Navbar ' class="p-3 mb-2 bg-black text-white">

            <ul className="nav nav-tabs" >
                <div className="col-5" >
                    <h2>Название</h2>
                </div>

                <li className="nav-item"  >
                    <NavLink className="nav-link " aria-current="page" to='/' >Главная</NavLink>
                </li>

                <li className="nav-item">
                    <NavLink className="nav-link" to='/users'>Люди</NavLink>
                </li>
                <li className="nav-item">
                    <NavLink className="nav-link" to='/dailytasks'>Мой день</NavLink>
                </li>
                {/*<li className="nav-item">
                    <a className="nav-link disabled">Отключенная</a>
                </li>*/}
                {/*<li className="nav-item dropdown">
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
    );
}
export default Navbar;