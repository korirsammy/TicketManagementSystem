import React, { Component } from "react";
import { Route, Redirect, Switch } from "react-router-dom";
import jwtDecode from "jwt-decode";
import TicketForm from "./components/TicketForm";
import NotFound from "./components/notFound";
import NavBar from "./components/navBar";
import LoginForm from "./components/loginForm";
import Logout from "./components/logout";
import RegisterForm from "./components/registerForm";
import "./App.css";
import Tickets from "./components/tickets";



class App extends Component {
  state = {};

  componentDidMount() {
    try {
      const jwt = localStorage.getItem("token");
      const user= jwtDecode(jwt);  
      //console.log(user.nameid);   
      this.setState({ user });

    } catch (ex) {
      
    }
  
  }

  render() {
    const { user } = this.state;
    return (
      <React.Fragment>
        <NavBar user={user} />
        <main className="container">
          <Switch>
          <Route path="/tickets/:id" component={TicketForm} /> 
          <Route path="/tickets" component={Tickets} />    
            <Route path="/register" component={RegisterForm} />
            <Route path="/login" component={LoginForm} />
            <Route path="/logout" component={Logout} />    
              
            <Route path="/not-found" component={NotFound} />
            <Redirect from="/" exact to="/tickets" />
            <Redirect to="/not-found" />
          </Switch>
        </main>
      </React.Fragment>
    );
  }
}

export default App;
