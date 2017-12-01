export const RouteParams = (function () {
    var pages = {
        Default: "",
        MainPage: "main",
        UserProfile: "my_profile",
        Profile: "user_profile"
    }
    var params = {
        UserId: "user_id",
        Page: "page"
    }
    function getParam(paramName) {
        var vals = [];
        if (location.search != "") {
            vals = decodeURIComponent(location.search.substr(1)).split("&");
            for (var i in vals) {
                vals[i] = vals[i].replace(/\+/g, " ").split("=");
                if (vals[i][0] == paramName) {
                    return vals[i][1];
                }
            }
        }
        return "";
    }
    return {
        Pages: pages,
        Params: params,
        GetParameter: getParam
    };
}());