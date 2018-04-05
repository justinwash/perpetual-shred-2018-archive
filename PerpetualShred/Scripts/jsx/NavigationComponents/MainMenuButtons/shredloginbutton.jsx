import React, { Component } from 'react';

class ShredLoginButton extends Component {
    constructor(props){
        super(props);
        this.click = this.click.bind(this);
    }
    
    click() {
        this.props.loginPageHandler();
        this.props.getViewHtml();
    }
    
    render() {
        var displayText = "";
        if (this.props.isLoggedIn)
        {
            displayText = "My Shredness";
        }
        else displayText = "Log In";
        
        return (
            <div id="navlink">
                <button id="navlink" type="button" onMouseDown={this.click}>
                    <span className="shredvidlistbutton-box">{displayText}</span>
                </button>
            </div>
        );
    }
}

export default ShredLoginButton;