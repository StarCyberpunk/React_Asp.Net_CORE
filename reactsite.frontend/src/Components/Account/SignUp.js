import React, {Component} from 'react';
import Register from "./Register";
import {Login} from "./Login";
import Cookies from "js-cookie";
import {useDispatch, useSelector} from "react-redux";
import UserCAB from "./UserCAB";

function SignUp() {
    const flag= Cookies.get('flag')

    if (flag==='true'){
        return <div>
            <UserCAB/>
        </div>
    }
    else {
        return <div>
            <Login/>
    </div>
    }


}

export default SignUp;