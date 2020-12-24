import React, { useContext } from 'react'
import Profile from '../containers/Profile/Profile'
import Login from '../containers/Login/Login'
import Register from '../containers/Register/Register'
import Home from '../containers/Home/Home'
import {Route, Switch} from 'react-router-dom'
import AppContext from '../contexts/appContext'

export const useRoutes = () =>{
    const {isLogged} = useContext(AppContext);
    const loggedNow = isLogged();
    return(
        <Switch>
            {getAvailableRoutes(loggedNow)}
        </Switch>
    )
}

function getAvailableRoutes(loggedNow) {
    return(
    <>
        <Route exact path='/' component={Home}></Route>
        <Route path="/register" component={Register} />
        <Route path="/login" component={Login} />
        {
            getAuthRoutes(loggedNow)
        }
    </>
    )
}

function getAuthRoutes(loggedNow) {
    if(loggedNow){
        return(
            <>
                <Route path="/profile" component={Profile}/>
            </>
        )
    }
    else{
        return;
    }
}
