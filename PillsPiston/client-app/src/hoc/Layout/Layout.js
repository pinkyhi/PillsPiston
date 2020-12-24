import React from 'react'
import Navigation from '../Navigation/Navigation'
import classes from './Layout.css'
import { useRoutes } from '../../hooks/routesSwitch.hook';

export const Layout = (props) => {
    const routes = useRoutes();
    return(
        <div className={classes.Layout}>
            <Navigation />
            <main>
                {routes}
                {props.children}
            </main>
        </div>
    )
}

export default Layout