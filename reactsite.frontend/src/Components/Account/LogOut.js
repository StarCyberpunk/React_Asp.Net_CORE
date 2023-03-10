import React, {Component} from 'react';
import Main from "../../Main";
import {useNavigate} from "react-router-dom";
import {useDispatch} from "react-redux";




const LogOut=()=> {

    const navigate=useNavigate();
    const dispatch=useDispatch();

    const goHome = () => {
        dispatch({type:"LogOut"})
        navigate("/");
    };
    return <div>
        <button onClick={goHome}>Go to home page</button>
    </div>;

}
export default LogOut;