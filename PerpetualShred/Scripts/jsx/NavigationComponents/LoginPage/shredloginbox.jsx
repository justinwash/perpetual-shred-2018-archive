import React, { Component } from "react";
import ShredLoginPage from './shredloginpage.jsx';
import ShredLoginButton from '../MainMenuButtons/shredloginbutton.jsx';
import axios from "axios";

class ShredLoginBox extends Component {
constructor(props){
    super(props);
    this.state = {
        isLoggedIn: null,
        viewHtml: null
    };
    this.getLoginStatus = this.getLoginStatus.bind(this);
    this.getLoginView = this.getLoginView.bind(this);
    this.getAccountView = this.getAccountView.bind(this);
    this.getViewHtml = this.getViewHtml.bind(this);
}

    componentDidMount() {
        this.getLoginStatus();
    }
    
    getLoginStatus() {
        axios.get("/Account/IsLoggedIn")
            .then(res => {
                const loginStatus = res.data;
                this.setState({isLoggedIn: loginStatus});
            })
    }
    
    getViewHtml() {
        if (this.state.isLoggedIn){
            this.getAccountView();
        } 
        else
            this.getLoginView();
    }

    getLoginView() {
        axios.get("/Account/Login")
            .then(res => {
                const loginHtml = res.data.toString();
                this.setState({ viewHtml: {__html: loginHtml} });
            })
    }

    getAccountView() {
        axios.get("/Manage/Index")
            .then(res => {
                const accountHtml = res.data.toString();
                this.setState({ viewHtml: {__html: accountHtml} });
            })
    }
    
    render() {
        return (
            <div>
                <ShredLoginButton loginPageHandler={this.props.loginPageHandler} 
                                    animSwitcher={this.props.animSwitcher}
                                    isLoggedIn={this.state.isLoggedIn}
                                    getViewHtml={this.getViewHtml}/>
                <ShredLoginPage animSwitcher={this.props.animSwitcher}
                                isLoggedIn={this.state.isLoggedIn}
                                viewHtml={this.state.viewHtml}/>
            </div>
        )
    }
}

export default ShredLoginBox;