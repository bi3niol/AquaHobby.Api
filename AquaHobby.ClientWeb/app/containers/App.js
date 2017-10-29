import React, { Component } from "react";
import ReactDOM from "react-dom";
import Test1 from "./test";
import Test2 from "./test2";
import Test3 from "./test3";
import { ClientApi as Api } from "../ApiProxy";
import { BrowserRouter as Router, Route, Link, browserHistory, IndexRoute } from 'react-router-dom';
import RegisterPanel from "../components/RegisterPanel";
import NavPanel from "../components/NavPanel";

export default class App extends Component {

    constructor(props) {
        super(props);
        this.state = {
            user: props.user,
            password: props.password,
            isLoged: false
        };
        var that = this;
        Api.login(this.state.user, this.state.password, (success) => {
            console.log("jestesmy w callback");
            that.setState({ isLoged: success }, () => Api.testGet().then((data) => console.log(data)));
        });
    }
    componentDidMount() {

    }
    render() {
        return (
            <Router>
                <div className="container">
                    <NavPanel />
                    
                    <Route exact path="/" component={Test1} />
                    <Route path="/test1" component={Test1} />
                    <Route path="/test2" component={Test2} />
                    <Route path="/test3" component={Test3} />
                    {this.state.isLoged ? "U Are Loged In" : "Sorry u are not loged"}
                    <div className="row">
                        <div className="col-md-6">
                        </div>
                        <div className="col-md-6">
                            <RegisterPanel />
                        </div>
                    </div>
                </div>
            </Router>
        );
    }
}
