import React, { Component } from 'react';
import LoginForm from '../Utilities/LoginForm.jsx';
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
                        Email: 'justin.wash@pm.me',
                        Password: password, 
                        RememberMe: isRemember
                    })
                }} />
        );
    }
}

export default ShredLoginForm;
