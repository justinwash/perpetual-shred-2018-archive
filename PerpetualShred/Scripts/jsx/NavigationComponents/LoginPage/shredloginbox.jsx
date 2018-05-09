import React, { Component } from "react";
import ShredLoginPage from './shredloginpage.jsx';
import ShredLoginButton from '../MainMenuButtons/shredloginbutton.jsx';
import ShredLogoutButton from '../MainMenuButtons/shredlogoutbutton.jsx';
import axios from "axios";
import AccountHelper from "../../../accounthelper";

class ShredLoginBox extends Component {
constructor(props){
    super(props);
    this.state = {
        isLoggedIn: null,
        viewHtml: null,
        regToggle: true
    };
    
    this.showLoginForm = this.showLoginForm.bind(this);
    this.getViewHtml = this.getViewHtml.bind(this);
    this.logout = this.logout.bind(this);
    this.showRegisterForm = this.showRegisterForm.bind(this);
}

    async componentDidMount() {
        var status = await AccountHelper.getLoginStatus();
        this.setState({isLoggedIn: status});
    }
    
    async getViewHtml() {
        if (this.state.isLoggedIn){
            this.setState({ regToggle: false })
        } 
        else {
            await this.showLoginForm();
            this.setState({ regToggle: true })
        }
    }

    async showLoginForm() {
        var view = await AccountHelper.getLoginView();
        this.setState({ viewHtml: {__html: view} });
            
    }

    async showRegisterForm() {
        var view = await AccountHelper.getRegView();
        this.setState({ viewHtml: {__html: view} });
            
    }
    
    async logout() {
        var loginStatus = await AccountHelper.logout();
        this.setState({ isLoggedIn: loginStatus });
    }
    
    render() {
        if (this.state.isLoggedIn) {
            return (
            <div>
                <ShredLoginButton loginPageHandler={this.props.loginPageHandler} 
                                    animSwitcher={this.props.animSwitcher}
                                    isLoggedIn={this.state.isLoggedIn}
                                    getViewHtml={this.getViewHtml}/>
                <ShredLogoutButton logoutHandler={this.logout}/>
                <ShredLoginPage animSwitcher={this.props.animSwitcher}
                                isLoggedIn={this.state.isLoggedIn}
                                viewHtml={this.state.viewHtml}/>
            </div>
        )}
        else return (
            <div>
                <ShredLoginButton loginPageHandler={this.props.loginPageHandler}
                                  animSwitcher={this.props.animSwitcher}
                                  isLoggedIn={this.state.isLoggedIn}
                                  getViewHtml={this.getViewHtml}/>
                <ShredLoginPage animSwitcher={this.props.animSwitcher}
                                isLoggedIn={this.state.isLoggedIn}
                                viewHtml={this.state.viewHtml}
                                showRegisterForm={this.showRegisterForm}
                                showLoginForm={this.showLoginForm}
                                regToggle={this.state.regToggle}/>
            </div>
        )
    }
}

export default ShredLoginBox;