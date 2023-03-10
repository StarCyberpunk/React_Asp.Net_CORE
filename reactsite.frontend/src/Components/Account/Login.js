import React, {Component} from 'react';
import {Form} from "./Form"
import {useDispatch, useSelector} from "react-redux";
import $api from "../../http";
import store from "../../Redux";
import Cookies from 'js-cookie'

const Login =()=> {
    const dispatch=useDispatch();
    const selector=useSelector(state => state.reducerUser.state)
    const response=async (login, password) => {
     const  z= await fetch('/user/auth', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({"login": login, "password": password})
        }).catch(error => console.error(error));
     const k=await z.json();
     Cookies.set('access_token',k['access_token'])
        Cookies.set('login',true)
     dispatch({type:"Auth",payload:{access_token:k['access_token'],login:login}})

    }


        return (
            <div>

                <Form
                    response={response}
                />
            </div>
        );

}

export {Login};