import React, { Component } from 'react';
import DayTasks from "./DayTasks";
import Donut from "./Donut";
import Cookies from "js-cookie";
import WeekTasks from "./WeekTasks";
import NextTask from "./NextTask";
import DayPlan from "./Planing/DayPlan";



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

        if(items.length===0){
            return (<div className="container-fluid" >
                <div><DayPlan/></div>
                <div>План на неделю</div>
            </div>);
        }
        else {
        return (

            <div className="container-fluid" >
                <div className="row justify-content-center">
                <div className="col-3">
                      <NextTask task={items[0]}/>

                </div>
                <div className="col-8">
                    <Donut />

                </div>
                </div>
                <div className="row justify-content-center">
                    <div className="col-3 ">
                        <div>Задачи на день</div>
                        {items.map(item =>
                            <DayTasks item={item}/>
                        )}
                    </div>
                    <div className="col-5">
                        <h3>Добавить задачу на сегодня</h3>
                        <DayPlan/>
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
        const  z= await fetch('http://localhost:5160/DailyTasks/GetAll', {
            method:'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8',
                'Authorization': 'Bearer '+ Cookies.get('access_token')
            },
            body:
                JSON.stringify({"start": new Date(),
                    "end": new Date()})
        });
        try {
            const k=await z.json();
            this.setState({ items:k, loading: false });
        }catch (e){
            this.setState({ items:[], loading: false });
        }




    }

}