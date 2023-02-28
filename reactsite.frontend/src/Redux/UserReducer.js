const State ={
    error: null,
    loading: true,
    items:[
        {
            id: 0,
            password: "string",
            login: "string",
            role: 0,
            profile: null,
            dailyTasks: null,
            access_token:null
        }
    ]

}
export const UserReducer=(state=State,action)=>{
    switch (action.type){
        case ("Update"):
            return{...state,items: state.items.id+action.payload}
        default:
            return state

    }

}