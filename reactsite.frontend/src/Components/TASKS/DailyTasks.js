import React, { Component } from 'react';

export default class DailyTasks extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            loading: true,
            items:[]
        };
    }
    static render(items) {

        return (
            <div className="dailytasks" >


                {items.map(item =>

                  <div ><h2> День:{item.day}</h2>

                      <table class="table">
                          <thead>
                          <tr>
                              <th scope="col">Название</th>
                              <th scope="col">Дата начала</th>
                              <th scope="col">Дата конца</th>
                          </tr>
                          </thead>
                          <tbody>
                          {item.activites.map(act=>
                              <tr>
                                  <td>{act.name}</td>
                                  <td>{act.dateBegin}</td>
                                  <td>{act.dateEnd}</td>

                              </tr>

                          )}
                          </tbody>
                      </table>

                  </div>


                )}

            <table>

            </table>

            </div>
        );
    }
    componentDidMount() {
        this.populateData();
    }
    render() {
        let contents = this.state.loading
            ? <p><em>Loading... </em></p>
            : DailyTasks.render(this.state.items);
        console.log(this.state.items)
        return (
            <div>
                <h1 id="tabelLabel" >Мои задачи</h1>
                {contents}
            </div>
        );
    }
    async populateData() {
        const response = await fetch('dailytasks');
        const data = await response.json();
        console.log(data);
        this.setState({ items: data, loading: false });
    }

}