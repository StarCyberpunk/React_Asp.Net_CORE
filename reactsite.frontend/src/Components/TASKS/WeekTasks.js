import React from 'react';


function WeekTasks({tasks}) {
    return (
        <div className='WeekTasks'>
            <table className="table">
                <thead>
                <tr>
                    <th scope="col">Название</th>
                    <th scope="col">Дата начала</th>
                    <th scope="col">Дата конца</th>
                </tr>
                </thead>
                <tbody>
            {tasks.map(task=>
            task.activites.map(act =>
                <tr>
                <td>{act.name}</td>
                <td>{act.dateBegin}</td>
                <td>{act.dateEnd}</td>

                </tr>
                ))}



                </tbody>
            </table>
        </div>
    );



}

export default WeekTasks;