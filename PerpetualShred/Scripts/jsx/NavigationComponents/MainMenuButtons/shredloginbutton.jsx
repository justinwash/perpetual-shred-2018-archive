import React, { Component } from 'react';

class ShredLoginButton extends Component {
    render() {
        return (
            <div id="navlink">
                <button id="navlink" type="button" onMouseDown={this.props.loginPageHandler}>
                    <span className="shredvidlistbutton-box">> Log In</span>
                </button>
            </div>
        );
    }
}

export default ShredLoginButton;