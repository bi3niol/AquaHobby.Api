import React, { Component } from "react";
import ReactDOM from "react-dom";
import { ClientApi as Api } from "../ApiProxy";

export default class NavPanel extends Component {

    constructor(props) {
        super(props);
        this.state = {
            isLogged: props.isLogged
        }
    }

    render() {
        var dom;
        if (this.state.isLogged)
            dom = <ul></ul>;
        else
            dom = <LogginPanel />
        return (
            <div className="navbar navbar-default navbar-fixed-top">
                <div className="container">
                    <div className="navbar-header">
                        <a className="navbar-brand" href="#">Aqua Hobby</a>
                    </div>
                    <div className="navbar-collapse collapse">
                        {dom}
                    </div>
                </div>
            </div>
        );
    }
}

class LogginPanel extends Component {
    constructor(props) {
        super(props);
        this.state = {
            User: "",
            Password: ""
        }
    }
    inputPropChange(event) {
        var target = event.target;
        this.setState((prevS) => { this.state.RegisterModel[target.name] = target.value; });

    }
    render() {
        return (
            <ul className="nav navbar-nav navbar-right">
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
                        <div className="btn-success btn" onClick={this.handleLogin}>
                            Zaloguj się
                     </div>
                    </a>
                </li>
            </ul>);
    }
}