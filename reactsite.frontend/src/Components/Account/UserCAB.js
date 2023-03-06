import React, {Component} from 'react';
import {Form} from "./Form"
import {useDispatch, useSelector} from "react-redux";
import $api from "../../http";
import store from "../../Redux";
import Cookies from 'js-cookie'

export default class UserCAB extends Component{
    /*const dispatch=useDispatch();
    const selector=useSelector(state => state.reducerUser.state)*/
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            loading: true,
            items:[]
        };
    }
    static renderRaz(items) {

        return (
            <div>   </div>


        );
    }
    componentDidMount() {
        this.response();
    }
    render() {
        let contents = this.state.loading
            ? <p>Wait</p>
            : UserCAB.renderRaz(this.state.items);
        console.log(this.state.items)
        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
    async response(){
        const  z= await fetch('/User', {
            method: 'Get',
            headers: {
                'Content-Type': 'application/json;charset=utf-8',
                'Authentication': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6IkFkbWluIiwic3ViIjoiMSIsInJvbGUiOiJBZG1pbiIsImV4cCI6MTY3ODA5Njk3NywiaXNzIjoiYXV0aFNlcnZlciIsImF1ZCI6InJlc291cmNlU2VydmVyIn0.AW_1l0bin8IPNrz43bZvl1uiTpHsBzeQZ89sKWHWk1o'
            },
        });
        const k=await z.json();
        console.log(k);
        this.setState({ items:k, loading: false });

    }
}

