import React, { useContext, useEffect } from 'react'
import AppContext from './contexts/appContext';
import { useHttpInterceptor } from './hooks/httpInterceptor.hook';
import fetchIntercept from 'fetch-intercept';

export const AppSettings = () => {
    useContext(AppContext);
    const {interceptor} = useHttpInterceptor();
    useEffect(()=>{
      fetchIntercept.register(interceptor);
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])
    return(
        <></>
    )
}

export default AppSettings