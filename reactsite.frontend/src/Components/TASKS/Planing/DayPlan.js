import React, {Component, useState} from 'react';
import {useDispatch, useSelector} from "react-redux";
import {useNavigate} from "react-router-dom";
import Cookies from "js-cookie";
import {Form} from "../../Account/Form";
import {FormDay} from "./FormDay";
import {render} from "react-dom";

function DayPlan() {

    const dispatch=useDispatch();
    const navigate=useNavigate();
    const selector=useSelector(state => state.reducerUser.state)
    const response=async (Name,DateBegin,DateEnd,TypeActivity) => {
        console.log(Name,DateBegin,DateEnd,TypeActivity)
        /*const  z= await fetch('/user/auth', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({"login": login, "password": password})
        }).catch(error => console.error(error));
        const k=await z.json();
        Cookies.set('access_token',k['access_token'],{ expires: 1 })
        Cookies.set('flag','true',{ expires: 1 })
        dispatch({type:"Auth",payload:{access_token:k['access_token'],login:login}})
        navigate("/");*/
    }
    



    return (

        <div>
            <FormDay
                response={response}/>


        </div>
    );




}

export default DayPlan;