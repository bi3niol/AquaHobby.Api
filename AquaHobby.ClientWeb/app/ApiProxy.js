import axios from 'axios';
const apiUrl = __API_URL__;

const handleErrors = err => {
    console.error(err);
    throw err;
};

const responseData = res => res.data;
const loginData = (user, password) => {
    var data = {
        grant_type: 'password',
        username: user,
        password: password
    };
    console.log("login");
    console.log(data);
    return data;
};
const tokenKey = "_token";
const headers = () => {
    var _headers = {};
    var appToken = "";
    if (sessionStorage.getItem(tokenKey))
        appToken = sessionStorage.getItem(tokenKey);
    if (appToken)
        _headers.Authorization = 'Bearer ' + appToken;
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
    }).then((response) => {
        if (response.data && response.data.access_token) {
            sessionStorage.setItem(tokenKey, response.data.access_token);
            callback(true);
        }
        else
            callback(false);
    }).catch((e) => {
        console.log("CATCH");
        console.log(e);
        callback(false);
    }),
    get: (url) => axios.get(`${apiUrl}${url}`, getProps())
        .then(responseData)
        .catch(handleErrors),
    post: (url, datay) => axios.post(`${apiUrl}${url}`, data, getProps())
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
    testGet: () => requests.get("/api/Users/Profile")
};