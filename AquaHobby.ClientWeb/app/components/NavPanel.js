import React, { Component } from "react";
import ReactDOM from "react-dom";
import { ClientApi as Api } from "../ApiProxy";

export default class NavPanel extends Component {

    render() {
        return (
            <div className="navbar navbar-default navbar-fixed-top">
                <div className="container">
                    <div className="navbar-header">
                        <label>Aqua Hobby</label>
                    </div>
                    <div className="navbar-collapse collapse navbar-right">
                        <ul className="nav navbar-nav">
                            <li>login</li>
                            <li>password</li>
                            <li></li>
                        </ul>
                    </div>
                </div>
            </div>
        );
    }
}