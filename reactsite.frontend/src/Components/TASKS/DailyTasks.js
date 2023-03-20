import React, { Component } from 'react';
import DayTasks from "./DayTasks";
import Donut from "./Donut";
import Cookies from "js-cookie";
import WeekTasks from "./WeekTasks";
import NextTask from "./NextTask";


export default class DailyTasks extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            loading: true,
            items:[]
        };
    }
    static render(items) {
        if(items.length==null){
            return (<div className="container-fluid" >
                <div>Добавить день</div>
            </div>);
        }
        else {
        return (

            <div className="container-fluid" >
                <div className="row justify-content-center">
                <div className="col-3">
                      <NextTask task={items[0]}/>

                </div>
                <div className="col-7">
                    <Donut />
                </div>
                </div>
                <div className="row justify-content-start">
                    <div className="col-3">
                        <div>Задачи на день</div>
                        {items.map(item =>
                            <DayTasks item={item}/>
                        )}
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
            : DailyTasks.render(this.state.items);
        console.log(this.state.items)
        return (
            <div>
                <h1 id="tabelLabel" >Мои задачи</h1>
                {contents}
            </div>
        );
    }
    async response(){
        const  z= await fetch('http://localhost:5160/DailyTasks', {
            method:'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8',
                'Authorization': 'Bearer '+ Cookies.get('access_token')
            },
            body:
                JSON.stringify({"start": new Date(),
                    "end": new Date()})
        });
        const k=await z.json();

        this.setState({ items:k, loading: false });

    }

}