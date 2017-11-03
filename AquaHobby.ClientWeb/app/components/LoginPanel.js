import React, { Component } from "react";
import ReactDOM from "react-dom";
import { ClientApi as Api } from "../ApiProxy";

export default class LoginPanel extends Component {
    constructor(props) {
        super(props);
        this.state = {
            IsProccessing: false,
            User: "",
            Password: "",
            HasError: false,
            ErrorMessages: []
        }
        this.inputPropChange = this.inputPropChange.bind(this);
        this.handleLogin = this.handleLogin.bind(this);
    }
    inputPropChange(event) {
        var target = event.target;
        this.setState({
            [target.name]: target.value
        });
    }

    handleLogin(event) {
        var _this = this;
        this.setState({ IsProccessing: true });
        Api.login(this.state.User, this.state.Password).then((res) => {
            _this.setState({ IsProccessing: false, HasError: false, ErrorMessages: [] });
            _this.props.loginCallBack(res.success, res.data);
        }).catch((error) => {
            _this.setState({ IsProccessing: false, HasError: true, ErrorMessages: ["Upewnij się, podano prawidłowy e-mail i hasło..."] });
        });
    }

    render() {
        return (
            <div className="nav navbar-nav navbar-right text-center">
                <form>
                    <ul className={this.state.HasError ? "has-error nav navbar-nav" : "nav navbar-nav"}>
                        <li>
                            <a>
                                <input className="form-control" name="User" placeholder="Email..." type="email" value={this.state.User} onChange={this.inputPropChange} />
                            </a>
                        </li>
                        <li>
                            <a>
                                <input className="form-control" name="Password" placeholder="Hasło..." type="password" value={this.state.Password} onChange={this.inputPropChange} />
                            </a>
                        </li>
                        <li>
                            <a>
                                <button type="submit" disabled={this.state.IsProccessing} className="form-control btn-success btn" onClick={this.handleLogin}>
                                    Zaloguj się
                                 </button>
                            </a>
                        </li>
                    </ul>
                </form>
                <div>
                    <div className={this.state.HasError ? "has-error tooltip right in" : "hide"}>
                        {this.state.ErrorMessages.map((mess, k) => {
                            return <label key={k} className="control-label">{mess}</label>
                        })}
                    </div>
                </div>
            </div>);
    }
}