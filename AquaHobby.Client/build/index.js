"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
require("todomvc-app-css/index.css");
var React = require("react");
var ReactDOM = require("react-dom");
var react_hot_loader_1 = require("react-hot-loader");
var renderApp = function () {
    ReactDOM.render(React.createElement(react_hot_loader_1.AppContainer, null,
        React.createElement("h1", null, "cos sie dzieje")), document.getElementById('root'));
};
if (module.hot) {
    var reRenderApp_1 = function () {
        renderApp();
    };
    module.hot.accept('./containers/App', function () {
        setImmediate(function () {
            reRenderApp_1();
        });
    });
}
renderApp();
//# sourceMappingURL=index.js.map