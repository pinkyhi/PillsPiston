import React, { useCallback, useEffect, useState } from 'react'
import classes from './Profile.css'
import { useProfile } from './profile.hook'
import Popup from 'reactjs-popup'
import DeviceAddingForm from '../../components/DeviceAddingForm'

const Profile = () => {
    return(
        <div className={classes.Profile}>
            <div className={classes.ProfileGames}>
                <h1>Profile</h1>
                <Popup trigger={<button> Add Device</button>} modal position="right center">
                    {
                        close => (
                            <DeviceAddingForm/>
                        )
                    }
                </Popup>
            </div>
        </div>
    )
}

export default Profile