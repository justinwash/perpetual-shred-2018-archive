import React, { Component } from 'react';
import LoginForm from '../Utilities/LoginForm.jsx';
import axios from 'axios';
import qs from 'qs';

class ShredLoginForm extends Component {
    constructor(props){
        super(props);
        this.state = {};
    }
    
    render () {
        return (
            <LoginForm
                onSubmit={(username, password, isRemember) => {
                    const data = qs.stringify({ Email: username, 
                                                Password: password, 
                                                RememberMe: isRemember});
                    axios.post("/Account/Login", data);
                }} />
        );
    }
}

export default ShredLoginForm;
