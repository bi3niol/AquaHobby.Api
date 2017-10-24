import 'todomvc-app-css/index.css';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { AppContainer } from 'react-hot-loader';

const renderApp = () => {
  ReactDOM.render(
      <AppContainer>
          <h1>cos sie dzieje</h1>
    </AppContainer>,
    document.getElementById('root')
  );
};

if (module.hot) {
  const reRenderApp = () => {
    renderApp();
  };

  module.hot.accept('./containers/App', () => {
    setImmediate(() => {
      reRenderApp();
    });
  });
}

renderApp();
