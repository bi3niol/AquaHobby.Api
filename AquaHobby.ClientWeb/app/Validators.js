
var Validators = {    
    Email: function (value) {
        if (value == "")
            return getResult(true, "");
        var pattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>() \[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return getResult(value.match(pattern)!=null,"Należy wpisać poprawny adres email...");
    },
    Password: function (value) {
        if (value == "")
            return getResult(true, "");
        return getResult(value.length>=6, "Hasło musi zawierać co najmniej 6 znaków...");
    },
    ConfirmPassword: function (pw, cpw) {
        if (cpw == "")
            return getResult(true, "");
        return getResult(pw == cpw, "Hasło i jego potwierdzenie musi być takie samo...");
    }
};
function getResult(res, message) {
    return {
        IsValid: res,
        Message: message
    };
}
module.exports = Validators;