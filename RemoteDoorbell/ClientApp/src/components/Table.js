import React, { Component } from 'react';
import { DateTime } from 'luxon';

export class Table extends Component {
  static displayName = Table.name;

  constructor(props) {
    super(props);
    this.state = { ringEntries: [], loading: true };
  }

  componentDidMount() {
    this.populateRingEntries();
  }

  renderRingEntryTable(ringEntries) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Data</th>
            <th>Godzina</th>
          </tr>
        </thead>
        <tbody>
          {ringEntries.map(entry =>
            <tr key={entry.date}>
                <td>{DateTime.fromISO(entry.date).toFormat('dd.MM.yyyy')}</td>
                <td>{DateTime.fromISO(entry.date).toFormat('HH:mm:ss')}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Ładowanie...</em></p>
      : this.renderRingEntryTable(this.state.ringEntries);

    return (
      <div>
        <h1 id="tabelLabel" >Przyciśnięcia dzwonka</h1>
        <p>Każde naciśnięcie dzwonka pozostawia wpis o określonej dacie i godzinie widoczny w tabeli</p>
        {contents}
      </div>
    );
  }

  async populateRingEntries() {
      const response = await fetch('ring', {
          headers: {
              Token: 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.WH9gipXjGvmngaWKbSdaFgGlr1_d0S95nWGb1KzEXIw',
          },
      }).then(r => r.json());

    const ringEntries = response.sort((a, b) => new Date(b.date) - new Date(a.date));

    this.setState({ ringEntries, loading: false });
  }
}
