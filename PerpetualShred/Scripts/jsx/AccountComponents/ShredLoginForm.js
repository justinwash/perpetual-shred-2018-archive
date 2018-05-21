import React, { Component } from 'react';
import { LoginForm } from 'react-form-login';
import axios from 'axios';

class ShredLoginForm extends Component {
    constructor(props){
        super(props);
        this.state = {};
    }
    
    render () {
        return (
            <LoginForm
                onSubmit={(username, password, isRemember) => {
                    axios.post("/Account/Login", {
                        Email: username,
                        Password: password, 
                        RememberMe: isRemember
                    })
                }} />
        );
    }
}

export default ShredLoginForm;
