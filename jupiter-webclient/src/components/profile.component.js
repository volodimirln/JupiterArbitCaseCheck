import React, { Component } from "react";
import { Navigate } from "react-router-dom";
import AuthService from "../services/auth.service";

export default class Profile extends Component {
  constructor(props) {
    super(props);

    this.state = {
      redirect: null,
      userReady: false,
      currentUser: {
        id: 0,
        name: "",
        surname: "",
        patronymic: "",
        email: "",
        phone: "",
        roleId: 0,
        dateRegistration: "",
        dataChange: "",
        role: null
    }
    };
  }

  componentDidMount() {

  const currentUser = AuthService.getCurrentUserWeb()

    AuthService.getCurrentUserWeb().then(
      response => {
        this.setState({
          currentUser: response.data
        });
      }
    );

    if (!currentUser) this.setState({ redirect: "/home" });
    this.setState({ currentUser: currentUser, userReady: true })
  }

  render() {
    if (this.state.redirect) {
      return <Navigate to={this.state.redirect} />
    }

    const { currentUser } = this.state;

    return (
      <div className="container">
        {(this.state.userReady) ?
        <div>
        <header className="jumbotron">
          <h3>
            <strong>{currentUser.name} {currentUser.surname} {currentUser.patronymic}</strong>
          </h3>
        </header>
        <p>
          <strong>Токен:</strong><p style={{wordBreak: "break-all", wordWrap:"break-word"}}>{"jp://"+localStorage.getItem("user").replace('"','').replace('"','')}</p>
        </p>
        <p>
          <strong>Номер:</strong>{" "}
          {currentUser.id}
        </p>
        <p>
          <strong>Почта:</strong>{" "}
          {currentUser.email}
        </p>
        <p>
          <strong>Телефон:</strong>{" "}
          {currentUser.phone}
        </p>
        <p>
          <strong>Дата регистрации:</strong>{" "}
          {currentUser.dateRegistration}
        </p>
        <p>
          <strong>Дата внесения изменений:</strong>{" "}
          {currentUser.dataChange}
        </p>
      </div>: null}
      </div>
    );
  }
}
