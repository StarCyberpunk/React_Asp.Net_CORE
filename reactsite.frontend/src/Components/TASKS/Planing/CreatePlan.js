import React, {Component, useState} from 'react';
import {useDispatch, useSelector} from "react-redux";
import {useNavigate} from "react-router-dom";
import Cookies from "js-cookie";
import {Form} from "../../Account/Form";
import {FormDay} from "./FormDay";
import {render} from "react-dom";

function CreatePlan() {

    const dispatch=useDispatch();
    const navigate=useNavigate();

    const response=async (Name,DateBegin,DateEnd,TypeActivity) => {
        console.log()

        const  z= await fetch('http://localhost:5160/DailyTasks/NewOrUpdate', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8',
                'Authorization': 'Bearer '+ Cookies.get('access_token')
            },
            body: JSON.stringify({
                "id": 0,
                "userId": 0,
                "day": new Date().toLocaleDateString(),
                "activites": [
                    {
                        "id": 0,
                        "dailyTasksId": 0,
                        "userId": 0,
                        "name": Name,
                        "dateBegin": new Date().toLocaleDateString().slice(6,10) +"-"+new Date().toLocaleDateString().slice(3,5)+"-"+new Date().toLocaleDateString().slice(0,2) +"T"+DateBegin+":00.00Z",
                        "dateEnd": new Date().toLocaleDateString().slice(6,10) +"-"+new Date().toLocaleDateString().slice(3,5)+"-"+new Date().toLocaleDateString().slice(0,2) +"T"+DateEnd+":00.00Z",
                        "doneType": "0",
                        "total": 0,
                        "typeActivity": parseInt( TypeActivity)
                    }
                ]
            })
        }).catch(error => console.error(error));
        const k=await z.json();

    }




    return (

        <div>
            <FormDay
                response={response}/>


        </div>
    );




}

export default CreatePlan;