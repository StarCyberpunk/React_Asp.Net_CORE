import {useState} from "react";

const FormDay=({response})=>{
    const [Name,setName]=useState('');
    const [DateBegin,setDateBegin]=useState('');
    const [DateEnd,setDateEnd]=useState('');
    const [TypeActivity,setTypeActivity]=useState('');

    return(
        <div className="col align-self-start">
            <div className="input-group mb-3">
                <span className="input-group-text" id="inputGroup-sizing-default">Название</span>
                <input
                    class="form-control"
                    type="name"
                    value={Name}
                    onChange={(e)=>setName(e.target.value)}
                    placeholder="Название активности"
                />
            </div>



            <div className="input-group">
                <span className="input-group-text">Начало и конец</span>
                <input
                    class="form-control"
                    type="time"
                    value={DateBegin}
                    onChange={(e)=>setDateBegin(e.target.value)}

                />
                <input
                    class="form-control"
                    type="time"
                    value={DateEnd}
                    onChange={(e)=>setDateEnd(e.target.value)}

                />
            </div>


            <div className="input-group mb-3">
                <label className="input-group-text" htmlFor="inputGroupSelect01">Тип активности</label>
                <select value={TypeActivity}
                        onChange={(e)=>setTypeActivity(e.target.value)}
                        className="form-select" id="inputGroupSelect01">
                    <option defaultValue selected >Выберите</option>
                    <option value="0">Работа</option>
                    <option value="1">Саморазвитие</option>
                    <option value="2">Отдых</option>
                </select>

            </div>

            <button onClick={()=>response(Name,DateBegin,DateEnd,TypeActivity)}>Создать</button>
        </div>
    )
}
export {FormDay};