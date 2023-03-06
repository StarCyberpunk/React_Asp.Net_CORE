import axios from 'axios';
import store from "../Redux/index";
import {useDispatch, useSelector} from "react-redux";

export const Api_URL='http://localhost:5160'
const $api=axios.create(
    {
        withCredentials:true,
        baseURL:Api_URL
    }
)
$api.interceptors.request.use((config)=>{
    config.headers.Authorization= "Bearer "+"Token"
    return config;
})
export default $api;