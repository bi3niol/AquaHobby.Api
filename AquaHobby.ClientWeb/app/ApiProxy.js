import axios from 'axios';
const apiUrl = __API_URL__;

const handleErrors = err => {
    console.error(err);
    throw err;
};

const responseData = res => res.data;

const tokenKey = "_token";
const setCookie = (name, val, time) => {
    var data = new Date();
    if (time) {
        data.setTime(data.getTime() + time);
        var expires = "; expires=" + data.toGMTString();
    }
    else {
        var expires = "";
    }
    console.log("cookie create");
    console.log(name + "=" + val + expires + "; path=/");
    document.cookie = name + "=" + val + expires + "; path=/";        
}
const removeCookie = (name) => {
    document.cookie = name + "=; expires=Thu, 01 Jan 1970 00:00:01 GMT; ";
}
const getCookie = (name) => {
    var cookies = document.cookie.split("; ");
    let l = cookies.length;
    for (var i = 0; i < l; i++) {
        var ctab = cookies[i].split("=");
        if (ctab[0] === name)
            return ctab[1];
    }
    return null;
}
const headers = () => {
    var _headers = {};
    var appToken = "";
    var tkn = getCookie(tokenKey);
    if (tkn)
        appToken =tkn;
    if (appToken)
        _headers.Authorization = 'Bearer ' + appToken;
    console.log("headers");
    console.log(_headers);

    return _headers;
};
const getProps = () => {
    return {
        headers: headers()
    }
};
const requests = {
    login: (user, password, callback) => axios.post(`${apiUrl}/Token`, `grant_type=password&username=${user}&password=${password}`, {
        headers: {
            "Content-Type": "application/x-www-form-urlencoded"
        }
    }).then(function(res){
        var _res = { success: false };
        console.log(res);
        if (res && res.data && res.data.access_token) {
            setCookie(tokenKey, res.data.access_token, res.data.expires_in);
            //sessionStorage.setItem(tokenKey,res.data.access_token);
            _res.success = true;
        }
        _res.data =responseData(res); 
        return _res;
    })
        .catch(handleErrors),
    get: (url) => axios.get(`${apiUrl}${url}`, getProps())
        .then(responseData)
        .catch(handleErrors),
    post: (url, data) => axios.post(`${apiUrl}${url}`, data, getProps())
        .then(responseData)
        .catch(handleErrors),
    put: (urlg, data) => axios.put(`${apiUrl}${url}`, data, getProps())
        .then(responseData)
        .catch(handleErrors),
    patch: (url, data) => axios.patch(`${apiUrl}${url}`, data, getProps())
        .then(responseData)
        .catch(handleErrors),
    del: (url) => axios.delete(`${apiUrl}${url}`, null, getProps())
        .then(responseData)
        .catch(handleErrors)
};

export const ClientApi = {
    login: (user, password, callback) => requests.login(user, password, callback),
    logout: () => removeCookie(tokenKey),//sessionStorage.removeItem(tokenKey),
    navinfo: ()=> requests.get("/api/navinfo"),
    register:(registerModel) => requests.post("/api/Account/Register",registerModel),
    testGet: () => requests.get("/api/Users/Profile"),
    IsLogged:() => getCookie(tokenKey)!=null //sessionStorage.getItem(tokenKey)!=null
};