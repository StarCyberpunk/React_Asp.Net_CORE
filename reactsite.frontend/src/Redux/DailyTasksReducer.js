const State ={
    error: null,
    loading: true,
    items:[{
        id: 0,
        userId: 0,
        day: "2023-02-23T18:30:42.024Z",
        activites: [
            {
                id: 0,
                dailyTasksId: 0,
                userId: 0,
                name: "string",
                dateBegin: "2023-02-23T18:30:42.024Z",
                dateEnd: "2023-02-23T18:30:42.024Z",
                typeActivity: 0
            }
        ]
    }]
}
export const DailyTasksReducer=(state=State,action)=>{
    switch (action.type){
        case ("Update"):
            return{...state,items: state.items.id+action.payload}
        default:
            return state

    }

}