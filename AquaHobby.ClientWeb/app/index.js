import React from "react";
import ReactDOM from "react-dom";
import App from "./containers/App";
import { BrowserRouter as Router, Route, Link, browserHistory, IndexRoute } from 'react-router-dom';
ReactDOM.render(
    <Router history={browserHistory} >
        <App/>
    </Router >, document.getElementById('root'))


    //    <Route path="/test1" component={Test1} />
    //    <Route path="/test2" component={Test2} />
    //< Route path= "/" component= { App } >
    //    </Route >