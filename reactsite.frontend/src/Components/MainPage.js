import React from 'react';
import {Link, NavLink} from "react-router-dom";
import {useDispatch, useSelector} from "react-redux";




function MainPage() {
    const dispatch=useDispatch();
    const id=useSelector(state => state.reducerDailyTasks.items[0].id)
    console.log(id);
    return (

        <div className='MainPage'>
            <div className="container">
                <h2>Я главная
                </h2>
            </div>
        </div>
    );
}
export default MainPage;