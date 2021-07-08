import React, { Component } from 'react';
import { Redirect, Route } from 'react-router';
import { Layout } from './components/Layout';
import { Table } from './components/Table';
import { Chart } from './components/Chart';


import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/table' component={Table} />
        <Route path='/chart' component={Chart} />
        <Redirect from='/' to='/table' />
      </Layout>
    );
  }
}
