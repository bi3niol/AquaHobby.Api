import React, { Component } from "react";
import ReactDOM from "react-dom";
import { ClientApi as Api } from "../ApiProxy";
import { BrowserRouter as Router, Route, Link, browserHistory, IndexRoute } from 'react-router-dom';
import { RouteParams as Rparams } from '../RouteParams';

export default class AppNavPanel extends Component {
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
            if (data)
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
        var myProfile = "?" + Rparams.Params.Page + "=" + Rparams.Pages.UserProfile;
        var mainPage = "?" + Rparams.Params.Page + "=" + Rparams.Pages.MainPage;
        return (
            <ul className="nav navbar-nav navbar-right text-center">
                <li>
                    <a href={myProfile}>
                        <div className="btn">{this.state.NavInfo.Name}</div>
                    </a>
                </li>
                <li>
                    <a>
                        <div className="nav-search">
                            <div className="input-group">
                                <input className="form-control" name="Filter" placeholder="Szukaj hobbistów..." type="text" value={this.state.Filter} onChange={this.inputPropChange} />
                                <div className="input-group-btn">
                                    <button type="submit" className="btn btn-default">
                                        <span className="glyphicon glyphicon-search"></span>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </a>
                </li>
                <li>
                    <a href={mainPage}>
                        <div className="btn">Strona główna</div>
                    </a>
                </li>
                <li className="dropdown">
                    <Link to="#" className="dropdown-toggle" data-toggle="dropdown">
                        <span className="glyphicon glyphicon-chevron-down" style={{ marginTop: "7px" }}></span>
                    </Link>
                    <ul className="dropdown-menu">
                        <li>
                            <Link to="#" disabled={this.state.IsProccessing} onClick={this.handleLogout}>
                                Wyloguj się
                     </Link>
                        </li>
                    </ul>
                </li>
            </ul>
        );
    }
}