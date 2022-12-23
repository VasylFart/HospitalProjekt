import { Component } from 'react';
import { Route } from 'react-router';

import { Counter } from './components/Counter';
import { FetchData } from './components/FetchData';
import { Home } from './components/Home';
import { Layout } from './components/Layout';

import './custom.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route component={Home} exact path="/" />
        <Route component={Counter} path="/counter" />
        <Route component={FetchData} path="/fetch-data" />
      </Layout>
    );
  }
}
