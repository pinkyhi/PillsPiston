import { useIdentity } from './identity.hook';
import { useHistory } from 'react-router-dom';
import { useQueryParams } from './queryParams.hook';

export const useHttpInterceptor = () => {
    const {insertParameter} = useQueryParams();
    const {refreshToken} = useIdentity();
    const history = useHistory();
    const interceptor = {
            request: function (url, config) {
                // Modify the url or config here
                let token = localStorage.getItem('token')
                if(token)
                {
                    const headers = {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${token}`,
                        'Accept': 'application/json'
                    }
                    return [url, { ...config, headers }];
                }
                else{
                    const headers = {
                        'Content-Type': 'application/json',
                        'Accept': 'application/json'
                    }
                    return [url, { ...config, headers }];
                }
            },
        
            requestError: function (error) {
                console.log('requestError')
                console.log(error)
                return Promise.reject(error)
            },
            
            response: function (response) {
                // Modify or log the reponse object
                if(!response.ok){
                    switch(response.status) {
                        case 401:
                            console.log('401 response')
                            let pointPath = window.location.pathname;
                            let token = localStorage.getItem('token')
                            let refresh = localStorage.getItem('refreshToken')
                            if(token && refresh){
                                // Refreshing
                                refreshToken(token, refresh).then(response => {
                                    console.log(response);
                                    if(response.ok){
                                        history.push(pointPath)
                                        alert('Session updated. Try again.')
                                    }
                                    else{
                                        history.push('/login')
                                        insertParameter('to', pointPath)
                                    }
                                })
                            }
                            else{
                                history.push('/login')
                                insertParameter('to', pointPath)
                            }
                            break;
                        case 400:
                            console.log('400 response')
                            alert(response.message);
                            break;
                        default:
                            break;
                    }
                }
                return response;
            },
        
            responseError: function (error) {
                // Handle a fetch error
                console.log('response')
                console.log(error)
                return Promise.reject(error);
            }
    }

    return {interceptor}
}