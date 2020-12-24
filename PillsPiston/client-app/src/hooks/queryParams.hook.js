import { useCallback } from "react";

export const useQueryParams = () => {
    const getParameterByName = useCallback((name, url = window.location.href) => {
        name = name.replace(/[[\]]/g, '\\$&');
        var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, ' '));
    }, [])

    const insertParameter = useCallback((key, value) => {
        key = encodeURIComponent(key);
        value = encodeURIComponent(value);
    
        // kvp looks like ['key1=value1', 'key2=value2', ...]
        var kvp = document.location.search.substr(1).split('&');
        let i=0;
    
        for(; i<kvp.length; i++){
            if (kvp[i].startsWith(key + '=')) {
                let pair = kvp[i].split('=');
                pair[1] = value;
                kvp[i] = pair.join('=');
                break;
            }
        }
    
        if(i >= kvp.length){
            kvp[kvp.length] = [key,value].join('=');
        }
    
        // can return this or...
        let params = kvp.join('&');
    
        // reload page with new params
        document.location.search = params;
    }, [])

    return {getParameterByName, insertParameter}
}