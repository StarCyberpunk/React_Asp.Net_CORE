import {combineReducers} from "redux";
import {createStore, applyMiddleware} from "redux";
import {configureStore} from "@reduxjs/toolkit";
import {DailyTasksReducer} from "./DailyTasksReducer";
import {UserReducer} from "./UserReducer";


const reducer =combineReducers(
    {
        reducerDailyTasks:DailyTasksReducer,
        reducerUser:UserReducer,

    }
);
const store=configureStore({reducer});

export default store;