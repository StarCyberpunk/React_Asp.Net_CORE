import React, {Component} from 'react';
import {Form} from "./Form"
import {useDispatch, useSelector} from "react-redux";
import $api from "../../http";
import store from "../../Redux";
import Cookies from 'js-cookie'

export default class UserCAB extends Component{
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
            <div>
                <p> Имя:{items.login}</p>
                <p> Адрес:{items.profile.address}</p>
                <p> Возраст:{items.profile.age}</p>
            </div>


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
                <h1 id="tabelLabel" >Личный кабинет</h1>

                {contents}
            </div>
        );
    }
    async response(){
        const  z= await fetch('http://localhost:5160/User', {
            headers: {
                'Content-Type': 'application/json;charset=utf-8',
                'Authorization': 'Bearer '+ Cookies.get('access_token')
            },
        });
        const k=await z.json();

        this.setState({ items:k, loading: false });

    }

}

