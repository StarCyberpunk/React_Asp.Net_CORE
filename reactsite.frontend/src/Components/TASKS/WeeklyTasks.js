import React, { Component } from 'react';
import DayTasks from "./DayTasks";
import Donut from "./Donut";
import Cookies from "js-cookie";
import WeekTasks from "./WeekTasks";
import NextTask from "./NextTask";
import ButtonsForDayTask from "./ButtonsForDayTask";

export default class WeeklyTasks extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            loading: true,
            items:[]
        };
    }
    static render(items) {
        if(items.length==0){
            return (<div className="container-fluid" >
                <div>Добавить неделю</div>
            </div>);
        }else {
        return (

            <div className="container-fluid" >
                <div className="row justify-content-start">
                    <div className="col-7">
                        <Donut />
                    </div>
                    <div className="col-3">
                        <WeekTasks tasks={items}/>
                    </div>

                </div>

            </div>
        );}
    }
    componentDidMount() {
        this.response();
    }
    render() {
        let contents = this.state.loading
            ? <p><em>Loading... </em></p>
            : WeeklyTasks.render(this.state.items);
        console.log(this.state.items)
        return (
            <div>
                {contents}
            </div>
        );
    }
    async response(){
        const  z= await fetch('http://localhost:5160/DailyTasks', {
            method:'GET',
            headers: {
                'Content-Type': 'application/json;charset=utf-8',
                'Authorization': 'Bearer '+ Cookies.get('access_token')
            },

        });
        const k=await z.json();

        this.setState({ items:k, loading: false });

    }

}