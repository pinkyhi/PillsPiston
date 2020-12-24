import React, {useState} from 'react'
import {useIdentity} from './../../hooks/identity.hook'
import classes from './Register.css'
import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'


const Register = () => {
    const {register} = useIdentity()
    const [form, setForm] = useState({
        email: '', username: '', password: ''
    })
    const { t, i18n } = useTranslation();
    const changeHandler = event => {
        setForm(prev =>{return{...prev, [event.target.name]: event.target.value}})
    }

    const registerHandler = async (event) => {
        event.preventDefault();
        await register({...form})
    }

    return(
            <div className={classes.Register}> 
                <h1>{t('register')}</h1>
                <form>
                <div className="form-group">
                    <label>{t('email')}</label>
                    <input onChange={changeHandler} type="email" name="email" className="form-control" placeholder={t("email")} />
                </div>

                <div className="form-group">
                    <label>{t('username')}</label>
                    <input onChange={changeHandler} type="text" name="username" className="form-control" placeholder={t("username")} />
                </div>

                <div className="form-group">
                    <label>{t('password')}</label>
                    <input onChange={changeHandler} type="password" name="password" className="form-control" placeholder={t("password")} />
                </div>

                <button onClick={registerHandler} type="submit" className="btn btn-dark btn-lg btn-block">Register</button>
                <p className="forgot-password text-right">
                {t('alreadyRegistered')} <Link to="/login">{t('login')}?</Link>
                </p>
            </form>
        </div>
    )
}

export default Register