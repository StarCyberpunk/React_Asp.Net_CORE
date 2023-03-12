import React from 'react';


function NextTask({task}) {
    try {


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
                        <tr>
                            <td>{task.activites[task.nowActivity].name}</td>
                            <td>{task.activites[task.nowActivity].dateBegin}</td>
                            <td>{task.activites[task.nowActivity].dateEnd}</td>

                        </tr>




                </tbody>
            </table>
        </div>
    );
    }catch (e){
      return(  <div>Отдых </div>);
    }


}

export default NextTask;