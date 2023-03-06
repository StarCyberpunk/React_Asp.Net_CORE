import React, {Component} from 'react';
import Register from "./Register";
import {Login} from "./Login";
import Cookies from "js-cookie";
import {useDispatch, useSelector} from "react-redux";
import UserCAB from "./UserCAB";

function SignUp() {
    const dispatch=useDispatch();
    const IsLogin=useSelector(state => state.reducerUser.IsLoggin)
    console.log(IsLogin)
    return (
            <div>
                {
                  IsLogin?( <UserCAB/>):(<Login/>)}




            </div>
        );

}

export default SignUp;