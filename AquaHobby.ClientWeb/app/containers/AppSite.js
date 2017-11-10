import React, { Component } from "react";
import ReactDOM from "react-dom";
import { ClientApi as Api } from "../ApiProxy";
import MainPage from "./MainPage";
import UserProfile from "./profile/UserProfile";
import { BrowserRouter as Router, Route, Switch, Link, browserHistory, IndexRoute } from 'react-router-dom';

export default class AppSite extends Component {

    render() {
        return (
            <Switch>
                <Route exact path="/" component={MainPage} replace />
                <Route path="/profile" component={UserProfile} replace />
                <Route path="/main" component={MainPage} replace />
            </Switch>
        );
    }
}
//<IndexRoute component={MainPage} />
