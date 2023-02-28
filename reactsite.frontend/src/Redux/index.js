import {combineReducers} from "redux";
import {createStore, applyMiddleware} from "redux";
import {configureStore} from "@reduxjs/toolkit";
import {DailyTasksReducer} from "./DailyTasksReducer";

const reducer =combineReducers(
    {
        reducerDailyTasks:DailyTasksReducer

    }
);
const store=configureStore({reducer});

export default store;