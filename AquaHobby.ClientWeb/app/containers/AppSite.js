import React, { Component } from "react";
import ReactDOM from "react-dom";
import { ClientApi as Api } from "../ApiProxy";
import MainPage from "./MainPage";
import UserProfile from "./profile/UserProfile";
import { BrowserRouter as Router, Route, Link, browserHistory, IndexRoute } from 'react-router-dom';

export default class AppSite extends Component {

    render() {
        return (
            <div>
                <Route exact path="/" component={MainPage} />
                <Route path="/profile" component={UserProfile} />
                <Route path="/main" component={MainPage} />
            </div>);
    }
}
//<IndexRoute component={MainPage} />
