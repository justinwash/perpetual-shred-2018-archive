import React, { Component } from "react";
import ShredLoginPage from './shredloginpage.jsx';
import ShredLoginButton from '../MainMenuButtons/shredloginbutton.jsx';

class ShredLoginBox extends Component {
    render() {
        return (
            <div>
                <ShredLoginButton loginPageHandler={this.props.loginPageHandler} 
                                    animSwitcher={this.props.animSwitcher}/>
                <ShredLoginPage animSwitcher={this.props.animSwitcher}/>
            </div>
        )
    }
}

export default ShredLoginBox;