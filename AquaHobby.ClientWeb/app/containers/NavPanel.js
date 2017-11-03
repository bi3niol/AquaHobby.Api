import React, { Component } from "react";
import ReactDOM from "react-dom";
import { ClientApi as Api } from "../ApiProxy";
import AppNavPanel from "../components/AppNavPanel";
import LoginPanel from "../components/LoginPanel";
import { Link } from 'react-router-dom';

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
                        <Link className="navbar-brand" to="/">Aqua Hobby</Link>
                        <button type="button" className="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                            <span className="icon-bar"></span>
                            <span className="icon-bar"></span>
                            <span className="icon-bar"></span>
                        </button>
                    </div>
                    <div className="collapse navbar-collapse" id="myNavbar">
                        {dom}
                    </div>
                </div>
            </nav>
        );
    }
}
