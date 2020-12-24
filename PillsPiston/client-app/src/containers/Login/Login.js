import React, {useState} from 'react'
import classes from './Login.css'
import {useIdentity} from './../../hooks/identity.hook'

const Login = () => {
    const {login} = useIdentity()
    const [form, setForm] = useState({
        email: '', password: ''
    })

    const changeHandler = event => {
        setForm(prev =>{return{...prev, [event.target.name]: event.target.value}})
    }
    
    const loginHandler = async (event) => {
        event.preventDefault();
        await login({...form})
    }

    return(
        <div className={classes.Login}>
            <h1>Login</h1>
            <form>
                <div className="form-group">
                    <label>Email</label>
                    <input onChange={changeHandler} type="email" className="form-control" placeholder="Enter email" name="email" />
                </div>

                <div className="form-group">
                    <label>Password</label>
                    <input onChange={changeHandler} type="password" className="form-control" placeholder="Enter password" name="password" />
                </div>

                <button type="submit" onClick={loginHandler} className="btn btn-dark btn-lg btn-block">Sign in</button>
            </form>
        </div>
    )
}

export default Login;