import React, { Component } from "react";
import ReactDOM from "react-dom";
import { ClientApi as Api } from "../../ApiProxy";
import TopSide from "./topcard/TopSide";
import LeftSide from "./leftcard/LeftSide";
import MainSide from "./maincard/MainSide";
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
            if(data)
                _this.setState(data);
            console.log(_this.state);
        })
    }
    render() {
        return (
            <div className="row">
                <div className="row">
                    <TopSide User={this.state} />
                </div>
                <div className="row">
                    <div className="col-md-4">
                        <LeftSide User={this.state}/>
                    </div>
                    <div className="col-md-8">
                        <MainSide User={this.state}/>
                    </div>
                </div>
            </div>);
    }
}
