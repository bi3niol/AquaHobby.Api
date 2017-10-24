
import React from "react";
import ReactDOM from "react-dom";

const App = React.createClass({
    render() {
        return <div> hello<h1>its me </h1></div>;
    }
});
ReactDOM.render(<App />, document.getElementById("app"));