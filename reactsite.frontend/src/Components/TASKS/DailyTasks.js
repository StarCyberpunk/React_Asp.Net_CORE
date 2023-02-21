import React, { Component } from 'react';
import DayTasks from "./DayTasks";
import Donut from "./Donut";

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
        this.populateData();
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
    async populateData() {
        const response = await fetch('dailytasks');
        const data = await response.json();
        console.log(data);
        this.setState({ items: data, loading: false });
    }

}