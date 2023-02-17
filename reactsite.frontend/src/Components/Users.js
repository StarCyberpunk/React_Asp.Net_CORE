import React, { Component } from 'react';

export default class Users extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            loading: true,
            items:[]
        };
    }
    static renderForecastsTable(items) {
       
        return (
           <ul>
                {items.map(item =>

                    <li>{item.id} and {item.login}
                        </li>
                    
                    )}
            </ul>
           
        );
    }
    componentDidMount() {
        this.populateData();
    }
    render() {
        let contents = this.state.loading
            ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
            : Users.renderForecastsTable(this.state.items);
        console.log(this.state.items)
        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
    async populateData() {
        const response = await fetch('user');
        const data = await response.json();
        console.log(data);
        this.setState({ items: data, loading: false });
    }

}