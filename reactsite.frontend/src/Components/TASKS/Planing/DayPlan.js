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

    const response=async (Name,DateBegin,DateEnd,TypeActivity) => {
        console.log(Name,DateBegin,DateEnd,TypeActivity)
        let DB=new Date().toJSON()
        const  z= await fetch('/DailyTask/AddActivity', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
            "id": 0,
                "userId": 0,
                "day": new Date.now().toJSON(),
                "activites": [
                {
                    "id": 0,
                    "dailyTasksId": 0,
                    "userId": 0,
                    "name": "string",
                    "dateBegin": "2023-02-23T18:30:42.024Z",
                    "dateEnd": "2023-02-23T18:30:42.024Z",
                    "typeActivity": 0
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

export default DayPlan;