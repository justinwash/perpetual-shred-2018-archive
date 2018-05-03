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
    
    this.getLoginView = this.getLoginView.bind(this);
    this.getAccountView = this.getAccountView.bind(this);
    this.getViewHtml = this.getViewHtml.bind(this);
    this.logout = this.logout.bind(this);
    this.getRegView = this.getRegView.bind(this);
}

    async componentDidMount() {
        var status = AccountHelper.getLoginStatus();
        this.setState({isLoggedIn: status});
    }
    
    getViewHtml() {
        if (this.state.isLoggedIn){
            this.getAccountView();
            this.setState({ regToggle: false })
        } 
        else {
            this.getLoginView();
            this.setState({ regToggle: true })
        }
    }

    getLoginView() {
        axios.get("/Account/Login")
            .then(res => {
                const loginHtml = res.data.toString();
                this.setState({ viewHtml: {__html: loginHtml} });
            })
    }

    getRegView() {
        axios.get("/Account/Register")
            .then(res => {
                const regHtml = res.data.toString();
                this.setState({ viewHtml: {__html: regHtml} });
            })
    }

    getAccountView() {
        axios.get("/Account/UserFavs")
            .then(res => {
                const accountHtml = res.data.toString();
                this.setState({ viewHtml: {__html: accountHtml} });
            });
    }
    
    logout() {
        axios.get("/Account/Logout")
            .then(res => {
                axios.get("/Account/IsLoggedIn")
                    .then(res => {
                        const loginStatus = res.data;
                        this.setState({isLoggedIn: loginStatus});
                    })
            })
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
                                getRegView={this.getRegView}
                                getLoginView={this.getLoginView}
                                regToggle={this.state.regToggle}/>
            </div>
        )
    }
}

export default ShredLoginBox;