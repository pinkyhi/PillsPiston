import React, {useState} from 'react'
import {useIdentity} from './../../hooks/identity.hook'
import classes from './Register.css'
import { Link } from 'react-router-dom'

const Register = () => {
    const {register} = useIdentity()
    const [form, setForm] = useState({
        email: '', username: '', password: ''
    })

    const changeHandler = event => {
        setForm(prev =>{return{...prev, [event.target.name]: event.target.value}})
    }

    const registerHandler = async (event) => {
        event.preventDefault();
        await register({...form})
    }

    return(
            <div className={classes.Register}> 
                <h1>Register</h1>
                <form>
                <div className="form-group">
                    <label>Email</label>
                    <input onChange={changeHandler} type="email" name="email" className="form-control" placeholder="Enter email" />
                </div>

                <div className="form-group">
                    <label>Username</label>
                    <input onChange={changeHandler} type="text" name="username" className="form-control" placeholder="Username" />
                </div>

                <div className="form-group">
                    <label>Password</label>
                    <input onChange={changeHandler} type="password" name="password" className="form-control" placeholder="Enter password" />
                </div>

                <button onClick={registerHandler} type="submit" className="btn btn-dark btn-lg btn-block">Register</button>
                <p className="forgot-password text-right">
                    Already registered <Link to="/login">log in?</Link>
                </p>
            </form>
        </div>
    )
}

export default Register