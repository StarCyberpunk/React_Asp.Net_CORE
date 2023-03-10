import React, { Component } from 'react';
import DayTasks from "./DayTasks";
import Donut from "./Donut";
import Cookies from "js-cookie";

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

        return (

            <div className="container-fluid" >
                <div className="row">
                <div className="col-3">

                {items.map(item =>
                      <DayTasks item={item}/>
                )}
                </div>
                <div className="col-5">
                    <Donut />
                </div>
                </div>
            </div>
        );
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
            headers: {
                'Content-Type': 'application/json;charset=utf-8',
                'Authorization': 'Bearer '+ Cookies.get('access_token')
            },
        });
        const k=await z.json();

        this.setState({ items:k, loading: false });

    }

}