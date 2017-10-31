import React, { Component } from "react";
import ReactDOM from "react-dom";
import RegisterPanel from "../components/RegisterPanel";
export default class HelloPage extends Component {

    render() {
        return (
            <div className="row">
                <div className="col-md-6">

                </div>
                <div className="col-md-6">
                    <RegisterPanel />
                </div>
            </div>
        );
    }
}