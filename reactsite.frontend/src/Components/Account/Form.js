import {useState} from "react";
import $api from "../../http";

/*async function response(login, password) {
    const a= await fetch('/user/auth', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body:JSON.stringify( {"login":login,"password":password})
    });
    console.log( await a.json());
    return a;
}*/
const Form=({response})=>{
    const [login,setLogin]=useState('');
    const [password,setPass]=useState('');

    return(
        <div>
            <input
            type="login"
            value={login}
            onChange={(e)=>setLogin(e.target.value)}
            placeholder="login"
            />
            <input
                type="password"
                value={password}
                onChange={(e)=>setPass(e.target.value)}
                placeholder="password"
            />
            <button onClick={()=>response(login,password)}>Войти</button>
        </div>
    )
}
export {Form};