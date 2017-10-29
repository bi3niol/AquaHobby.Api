import React, { Component } from "react";
import ReactDOM from "react-dom";
import { ClientApi as Api } from "../ApiProxy";

export default class RegisterPanel extends Component {
    constructor(props) {
        super(props);
        this.state = {
            RegisterModel: {
                Email: "",
                Password: "",
                ConfirmPassword: ""
            }
        }
        this.mailChange = this.mailChange.bind(this);
        this.pwChange = this.pwChange.bind(this);
        this.confirmPwChange = this.confirmPwChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    mailChange(event) {
        var value = event.target.value;
        this.setState((prevS) => { this.state.RegisterModel.Email = value; });
    }
    pwChange(event) {
        var value = event.target.value;
        this.setState((prevS) => { this.state.RegisterModel.Password = value; });
    };
    confirmPwChange(event) {
        var value = event.target.value;
        this.setState((prevS) => { this.state.RegisterModel.ConfirmPassword = value; });
    }

    handleSubmit(event) {
        console.log("event");
        console.log(event);
        console.log("state");
        console.log(this.state);

        //alert('A name was submitted: ' + this.state.Email + " " + this.state.Password + " " + this.state.ConfirmPassword);
        //Api.register(this.state).then((data) => { console.log(data); alert("chyba ok"); });
        //event.preventDefault();
    }

    render() {
        return (
            <div className="modal-content">
                <div className="modal-header">
                    <div className="col-md-12 text-info">
                        <h3>
                            <label className="">Dołącz już teraz</label>
                        </h3>
                    </div>
                </div>
                <div className="modal-body text-primary">
                    <div className="row padding-top">
                        <div className="col-md-6">
                            <label>
                                Adres e-mail:
                            </label>
                        </div>
                        <input className="col-md-6 input-cw" name="Email" placeholder="wpisz e-mail..." type="email" value={this.state.RegisterModel.Email} onChange={this.mailChange} />
                    </div>
                    <div className="row padding-top">
                        <div className="col-md-6">
                            <label>
                                Hasło:
                            </label>
                        </div>
                        <input className="col-md-6 input-cw" name="Password" type="password" placeholder="wpisz hasło..." value={this.state.RegisterModel.Password} onChange={this.pwChange} />
                    </div>
                    <div className="row padding-top">
                        <div className="col-md-6">
                            <label>
                                Potwierdź hasło:
                           </label>
                        </div>
                        <input className="col-md-6 input-cw" name="ConfirmPassword" placeholder="potwierdź hasło..." type="password" value={this.state.RegisterModel.ConfirmPassword} onChange={this.confirmPwChange} />
                    </div>

                </div>
                <div className="modal-footer">
                    <div className="text-center">
                        <div className="btn-success btn" disabled={true ? true : false} onClick={this.handleSubmit}>
                            Zarejestruj się
                            </div>
                    </div>
                </div>
            </div >
        );

    }
}