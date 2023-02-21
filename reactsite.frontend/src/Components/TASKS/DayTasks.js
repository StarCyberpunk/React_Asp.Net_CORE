import React from 'react';
import {Link, NavLink} from "react-router-dom";




function DayTasks({item}) {
    return (

        <div className='DayTasks'>
            <h2 > День:{item.day}</h2>
            <table className="table">
                <thead>
                <tr>
                    <th scope="col">Название</th>
                    <th scope="col">Дата начала</th>
                    <th scope="col">Дата конца</th>
                </tr>
                </thead>
                <tbody>
                {item.activites.map(act =>
                    <tr>
                        <td>{act.name}</td>
                        <td>{act.dateBegin}</td>
                        <td>{act.dateEnd}</td>

                    </tr>
                )}
                </tbody>
            </table>

        </div>
    );
}
export default DayTasks;