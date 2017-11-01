import React, { Component } from "react";
import ReactDOM from "react-dom";
import { ClientApi as Api } from "../ApiProxy";

export default class NavPanel extends Component {

    constructor(props) {
        super(props);
    }

    render() {
        var dom;
        if (this.props.isLogged)
            dom = <AppNavPanel loginCallBack={this.props.loginCallBack} />;
        else
            dom = <LoginPanel loginCallBack={this.props.loginCallBack} />
        return (
            <nav className="navbar navbar-default navbar-fixed-top">
                <div className="container">
                    <div className="navbar-header">
                        <a className="navbar-brand" href="#">Aqua Hobby</a>
                    </div>
                    {dom}
                </div>
            </nav>
        );
    }
}

class AppNavPanel extends Component {
    constructor(props) {
        super(props);
        this.state = {
            Filter: "",
            NavInfo: {
                Name: "deault"
            }
        }
        this.inputPropChange = this.inputPropChange.bind(this);
        this.handleLogout = this.handleLogout.bind(this);
    }
    componentDidMount() {
        var _this = this;
        Api.navinfo().then((data) => {
            _this.setState({ NavInfo: data });
        }).catch((error) => { })
    }
    handleLogout(event) {
        Api.logout();
        this.props.loginCallBack(false, {});
    }
    inputPropChange(event) {
        var target = event.target;
        console.log("inputPropChange");
        this.setState({
            [target.name]: target.value
        });
    }
    render() {
        return (
            <div className="navbar-nav navbar-right">
                <ul className="nav navbar-nav">
                    <li>
                        <a>
                            <div className="btn">{this.state.NavInfo.Name}</div>
                        </a>
                    </li>
                    <li>
                        <a>
                            <form>
                                <div className="nav-search">
                                    <div className="input-group">
                                        <input className="form-control" name="Filter" placeholder="Szukaj hobbistów..." type="text" value={this.state.Filter} onChange={this.inputPropChange} />
                                        <div className="input-group-btn">
                                            <button type="submit" className="btn btn-default">
                                                Szukaj
                            </button>
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </a>
                    </li>
                    <li>
                        <a>
                            <div className="btn">Strona główna</div>
                        </a>
                    </li>
                    <li className="dropdown">
                        <a href="#" className="dropdown-toggle" data-toggle="dropdown">
                            <span className="glyphicon glyphicon-chevron-down" style={{marginTop:"7px"}}></span>
                        </a>
                        <ul className="dropdown-menu">
                            <li>
                                <a href="#" disabled={this.state.IsProccessing} onClick={this.handleLogout}>
                                    Wyloguj się
                     </a>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>);
    }
}

class LoginPanel extends Component {
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
        console.log("inputPropChange");
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
            <div className="navbar-right">
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