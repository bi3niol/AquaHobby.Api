import React, { Component } from "react";
import ReactDOM from "react-dom";
import { ClientApi as Api } from "../ApiProxy";

export default class Register extends Component{
    constructor(props) {
        super(props);
        this.state = {
            Email: "",
            Password: "",
            ConfirmPassword: ""
        }
        this.mailChange = this.mailChange.bind(this);
        this.pwChange = this.pwChange.bind(this);
        this.confirmPwChange = this.confirmPwChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    mailChange(event){
        this.setState({Email: event.target.value});
    }
    pwChange(event){
        this.setState({Password: event.target.value});
    };
    confirmPwChange(event){
        this.setState({ConfirmPassword: event.target.value});
    }

    handleSubmit(event) {
        alert('A name was submitted: ' + this.state.Email + " "+this.state.Password + " "+this.state.ConfirmPassword);
        Api.register(this.state).then((data)=>{console.log(data); alert("chyba ok");});
        event.preventDefault();
    }

    render() {
        return(
               <form>
                  <label>
    Mail:
                  <input type="text" value={this.state.Email} onChange={this.mailChange} />
                </label>
                <label>
        Password:
                  <input type="password" value={this.state.Password} onChange={this.pwChange} />
                </label>
                <label>
                      Confirm Password:
        <input type="password" value={this.state.ConfirmPassword} onChange={this.confirmPwChange} />
                </label>
                <input type="button" value="Submit" onClick={this.handleSubmit}/>
              </form>
            );
}
}