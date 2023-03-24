import React from 'react';
import Cookies from "js-cookie";

const Done=async () => {
    const  z= await fetch('/user/auth', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify({"login": "login" })
    }).catch(error => console.error(error));
    const k=await z.json();


}
function CalcDate(task){

    if(task.activites[task.nowActivity].total.toString()==="0"){
        return  Math.floor( Date.parse(task.activites[task.nowActivity].dateEnd)- Date.parse(task.activites[task.nowActivity].dateBegin))
    }
    else {
        return Math.floor( Date.parse(task.activites[task.nowActivity].dateEnd)-  task.activites[task.nowActivity].total- Date.parse(task.activites[task.nowActivity].dateBegin))
    }
}
const CountDown = ({ millisec = 0 }) => {
    let r=millisec;
    let hours=parseInt((r/(1000*60*60)));
    r=r-(parseInt((r/(1000*60*60)))*(1000*60*60));
    let minutes=parseInt((r/(1000*60)));
    r=r-(parseInt((r/(1000*60)))*(1000*60));
    let seconds=parseInt((r/1000));
    r=r-(parseInt((r/1000))*1000);
    const [paused, setPaused] = React.useState(false);
    const [over, setOver] = React.useState(false);
    const [[h, m, s], setTime] = React.useState([hours, minutes, seconds]);

    const tick = () => {
        if (paused || over) return;

        if (h === 0 && m === 0 && s === 0) {
            setOver(true);
        } else if (m === 0 && s === 0) {
            setTime([h - 1, 59, 59]);
        } else if (s == 0) {
            setTime([h, m - 1, 59]);
        } else {
            setTime([h, m, s - 1]);
        }

    };

    const reset = () => {
        setTime([parseInt(hours), parseInt(minutes), parseInt(seconds)]);
        setPaused(false);
        setOver(false);
    };

    React.useEffect(() => {
        const timerID = setInterval(() => tick(), 1000);
        return () => clearInterval(timerID);
    });

    return (
        <div>
            <p>{`${h.toString().padStart(2, '0')}:${m
                .toString()
                .padStart(2, '0')}:${s.toString().padStart(2, '0')}`}</p>
            <div>{over ? "Time's up!" : ''}</div>
            <div className='BFDT'>
                <button onClick={()=>Done()}>Done</button>
                <button>Skip</button>

            {/*<button onClick={() => setPaused(!paused)}>
                {paused ? 'Resume' : 'Pause'}
            </button>
            <button onClick={() => reset()}>Restart</button>*/}
            </div>
        </div>
    );
};
function NextTask({task}) {
    try {
 console.log(CalcDate(task))
    return (
        <div className='WeekTasks'>

            <div className="card text-bg-primary mb-3">
                <div className="card-header">Следующая задача:{task.activites[task.nowActivity].name}</div>
                <div className="card-body">
                    <p className="card-text">
                        <a></a>
                       <a> <CountDown millisec={CalcDate(task)} /></a>
                    </p>
                </div>
            </div>


        </div>
    );
    }catch (e){
      return(  <div>Отдых </div>);
    }


}

export default NextTask;