import * as React from 'react';
import { Provider } from 'mobx-react';
import DevTools from 'mobx-react-devtools'

export default class Root extends React.Component{
  render() {
    return (
      <Provider>
        <div>
          siemanko
          <DevTools />
        </div>
        </Provider>
    );
  }
}