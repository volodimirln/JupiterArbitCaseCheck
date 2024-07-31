import React, { Component } from "react";


export default class Home extends Component {
  constructor(props) {
    super(props);

    this.state = {
      content: ""
    };
  }

  
  render() {
    return (
      <div className="container">
        <header className="jumbotron">
          <h3>Добро пожаловать в систему арбитражных дел, Юпитер!</h3>
        </header>
      </div>
    );
  }
}
