import Cookies from "js-cookie";
const State ={
            id: 0,
            login: "string",
            role: null,
            profile: null,
            dailyTasks: null,
            access_token:null,
            IsLoggin:false
}
export const UserReducer=(state=State,action)=>{
    switch (action.type){
        case ("Auth"):

            return{...state, access_token: action.payload.access_token,login: action.payload.login,IsLoggin: true}
        case ("GetDailyTasks"):
            return {...state,dailyTasks: action.payload.DailyTasks}
        case ("LogOut"):
            Cookies.set('access_token','null')
            Cookies.set('flag','false')
             return{...state, access_token: null,login: null,IsLoggin: false}
        default:
            return state

    }

}
