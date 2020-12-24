import React, { useState } from 'react'
import jwt from 'jwt-decode'


const AppContext = React.createContext();

export default AppContext;

export const useDefaultValue = () => {
    let token = localStorage.getItem('token')
    const [decodedToken, setDecodedToken] = useState(token ? jwt(token) : null);
    const isLogged = () => {
        if(decodedToken){
            var current_time = new Date().getTime() / 1000
            if (!(current_time > decodedToken.exp)) {
                return true
            }
        }
        return false
    }

    return {decodedToken, setDecodedToken, isLogged}
}