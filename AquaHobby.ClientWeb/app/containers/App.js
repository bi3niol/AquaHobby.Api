import React, { Component } from "react";
import ReactDOM from "react-dom";
import { ClientApi as Api } from "../ApiProxy";
import HelloPage from "./HelloPage";
import { BrowserRouter as Router, Route, Link, browserHistory, IndexRoute } from 'react-router-dom';
import NavPanel from "../components/NavPanel";

export default class App extends Component {

    constructor(props) {
        super(props);
        this.state = {
            isLogged: false
        };
    }
    LogginCallBack() {

    }
    componentDidMount() {

    }
    render() {
        var dom;
        if (this.state.isLoged)
            dom = <div></div>;
        else
            dom = <HelloPage />;
        return (
            <div className="container">
                <NavPanel isLogged={this.state.isLogged} />
                <div className="app-content">
                    {dom}
                </div>
            </div>
        );
    }
}
