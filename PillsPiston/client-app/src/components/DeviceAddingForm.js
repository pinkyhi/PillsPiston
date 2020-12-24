import React, { useState } from 'react'
import classes from './DeviceAddingForm.css'

const DeviceAddingForm = () => {
    const [form, setForm] = useState({title: '', password: '', capacity: ''});
    const changeHandler = event => {
        setForm(prev =>{return{...prev, [event.target.name]: event.target.value}})
    }
    return(
        <div className={classes.DeviceAddingForm}>
        <h1>Add new game</h1>
        <input type="text" onChange={changeHandler} name="title" placeholder="Id" value='' />
        <input type="text" onChange={changeHandler} name="password" placeholder="Name" />
    </div>
    )
}

export default DeviceAddingForm