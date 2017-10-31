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
            isLogged: Api.IsLogged()
        };
        this.LoginCallBack = this.LoginCallBack.bind(this);
    }
    LoginCallBack(success,response) {
        console.log(success);
        this.setState({isLogged:success?true:false})
        console.log(response);
    }
    componentDidMount() {
        this.setState({isLogged: Api.IsLogged()});
    }
    render() {
        var dom;
        if (this.state.isLogged)
            dom = <div></div>;
        else
            dom = <HelloPage />;
        return (
            <div className="container">
                <NavPanel loginCallBack={this.LoginCallBack} isLogged={this.state.isLogged} />
                <div className="app-content">
                    {dom}
                </div>
            </div>
        );
    }
}
