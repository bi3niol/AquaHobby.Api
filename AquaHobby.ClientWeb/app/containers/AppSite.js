import React, { Component } from "react";
import ReactDOM from "react-dom";
import { ClientApi as Api } from "../ApiProxy";
import MainPage from "./MainPage";
import UserProfile from "./profile/UserProfile";
import { BrowserRouter as Router, Route, Switch, Link, browserHistory, IndexRoute } from 'react-router-dom';
import { RouteParams as Rparams } from '../RouteParams';

export default class AppSite extends Component {

    render() {
        var page = Rparams.GetParameter(Rparams.Params.Page);
        var component = <MainPage />;
        switch (page) {
            case Rparams.Pages.Default:
                component = <MainPage />;
                break;
            case Rparams.Pages.MainPage:
                component = <MainPage />;
                break;
            case Rparams.Pages.UserProfile:
                component = <UserProfile />;
                break;
            default:
        }
        return (
            <div>
                {component}
            </div>
        );
    }
}
//<IndexRoute component={MainPage} />
