import React, { Component } from "react";
import ReactDOM from "react-dom";
import Test1 from "./test";
import Test2 from "./test2";
import Test3 from "./test3";
import { BrowserRouter as Router, Route, Link, browserHistory, IndexRoute } from 'react-router-dom';
export default class App extends Component {
    render() {
        return (
            <Router>
            <div className="container">
                    <ul>
                        <li><Link to="/test1">Home</Link></li>
                        <li><Link to="/test2">About</Link></li>
                        <li><Link to="/test3">Contact</Link></li>
                    </ul>
                <Route exact path="/" component={Test1} />
                <Route path="/test1" component={Test1} />
                <Route path="/test2" component={Test2} />
                <Route path="/test3" component={Test3} />
            </div>
        </Router>
        );
    }
}
