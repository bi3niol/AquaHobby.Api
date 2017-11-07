import React, { Component } from "react";
import ReactDOM from "react-dom";
import { ClientApi as Api } from "../ApiProxy";
import Validators from "../Validators";
export default class RegisterPanel extends Component {
    constructor(props) {
        super(props);
        this.state = {
            IsProcessing: false,
            IsRegistered: false,
            RegisterError: false,
            RegisterErrorObj: [],
            RegisterModel: {
                Email: "",
                Password: "",
                ConfirmPassword: ""
            }
        }
        this.inputPropChange = this.inputPropChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    inputPropChange(event) {
        var target = event.target;
        this.setState((prevS) => { this.state.RegisterModel[target.name] = target.value; });

    }
    handleSubmit(event) {
        var _this = this;
        this.setState({ IsProcessing: false });
        Api.register(this.state.RegisterModel).then(function (res) {
            console.log(res);
            _this.setState({
                IsProcessing: false,
                IsRegistered: true,
                RegisterErrorObj: [],
                RegisterError: false,
                RegisterModel: {
                    Email: "",
                    Password: "",
                    ConfirmPassword: ""
                }
            });
        }).catch(function (res) {
            console.log(res);
            if (res && res.response && res.response.data && res.response.data.ModelState && res.response.data.ModelState.errors)
                _this.setState({
                    IsProcessing: false,
                    RegisterErrorObj: res.response.data.ModelState.errors,
                    IsRegistered: false,
                    RegisterError: true
                });
        });
    }

    render() {
        var validEmail = Validators.Email(this.state.RegisterModel.Email);
        var validPassword = Validators.Password(this.state.RegisterModel.Password);
        var validConfirmPassword = Validators.ConfirmPassword(this.state.RegisterModel.Password, this.state.RegisterModel.ConfirmPassword);
        var formValid = function (cl) {
            if (!cl.state.RegisterModel.Email || !cl.state.RegisterModel.Password || !cl.state.RegisterModel.ConfirmPassword)
                return false;
            return validEmail.IsValid && validPassword.IsValid && validConfirmPassword.IsValid;
        }(this);
        return (
            <div className="form-group">
                <div className="form-inline">
                    <div className="col-md-12 text-info text-center">
                        <h3>
                            <label className="">Dołącz już teraz</label>
                        </h3>
                    </div>
                </div>
                <div className="text-primary">
                    <div className="row form-group">
                        <div className="col-md-6">
                            <label>
                                Adres e-mail:
                            </label>
                        </div>
                        <div className={validEmail.IsValid ? "col-md-6" : "col-md-6 has-error"}>
                            <div className={validEmail.IsValid ? "hide" : "control-label"}>{validEmail.Message}</div>
                            <input className="form-control" name="Email" placeholder="wpisz e-mail..." type="email" value={this.state.RegisterModel.Email} onChange={this.inputPropChange} />
                        </div>
                    </div>
                    <div className="row form-group">
                        <div className="col-md-6">
                            <label>
                                Hasło:
                            </label>
                        </div>
                        <div className={validPassword.IsValid ? "col-md-6" : "col-md-6 has-error"}>
                            <div className={validPassword.IsValid ? "hide" : "control-label"}>{validPassword.Message}</div>
                            <input className="form-control" name="Password" type="password" placeholder="wpisz hasło..." value={this.state.RegisterModel.Password} onChange={this.inputPropChange} />
                        </div>
                    </div>
                    <div className="row form-group">
                        <div className="col-md-6">
                            <label>
                                Potwierdź hasło:
                           </label>
                        </div>
                        <div className={validConfirmPassword.IsValid ? "col-md-6" : "col-md-6 has-error"}>
                            <div className={validConfirmPassword.IsValid ? "hide" : "control-label"}>{validConfirmPassword.Message}</div>
                            <input className="form-control" name="ConfirmPassword" placeholder="potwierdź hasło..." type="password" value={this.state.RegisterModel.ConfirmPassword} onChange={this.inputPropChange} />
                        </div>
                    </div>
                </div>
                <div className="row form-group text-center">
                    <div className={this.state.IsRegistered ? "has-success" : "hide"}>
                        <div className="control-label">Pomyślnie Zarejestrowano</div>
                    </div>
                    <div className={this.state.RegisterError ? "has-error" : "hide"}>
                        <div className="control-label">
                            {this.state.RegisterErrorObj.map((error, i) => {
                                return <div key={i}>{error}</div>
                            })}
                        </div>
                    </div>
                </div>
                <div className="row form-group">
                    <div className="text-center">
                        <div className="btn-success btn" disabled={!formValid && !this.state.IsProcessing? true : false} onClick={this.handleSubmit}>
                            Zarejestruj się
                        </div>
                    </div>
                </div>
            </div >
        );
    }
}