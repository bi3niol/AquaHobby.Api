import React, { Component } from "react";
import ReactDOM from "react-dom";
import { ClientApi as Api } from "../../ApiProxy";
import { BrowserRouter as Router, Route, Link, browserHistory, IndexRoute } from 'react-router-dom';

export default class UserProfile extends Component {
    constructor(props) {
        super(props);
        this.state = {
            Aquariums: [],
            Gallery: [],
            Id: "",
            Name: ""
        }
    }
    componentDidMount() {
        var _this = this;
        Api.profile().then((data) => {
            _this.setState(data);
            console.log(_this.state);
        })
    }
    render() {
        return (
            <div className="row">
                <div className="row">
                    {this.state.Name}
                </div>
                <div className="row">
                    <div className="col-md-4">
                        left side
                    </div>
                    <div className="col-md-8">
                        main content
                    </div>
                </div>
            </div>);
    }
}
