import React from 'react';
import Cookies from "js-cookie";


function ButtonsForDayTask() {

    const start_pause=async () => {
        const  z= await fetch('/user/auth', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({"login": "login" })
        }).catch(error => console.error(error));
        const k=await z.json();


    }

    return (
        <div className='BFDT'>
            <button onClick={()=>start_pause()}>Start/Pause</button>
            <button>Skip</button>
        </div>
    );



}

export default ButtonsForDayTask;