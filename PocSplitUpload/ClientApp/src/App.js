import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Upload } from './components/Upload';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <h1>POC - Split Upload (UI)</h1>
        <hr />
        <Route exact path='/' component={Upload} />
      </Layout>
    );
  }
}
