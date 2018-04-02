import React, { Component } from 'react';

class ShredLogoutButton extends Component {

    render() {
        return (
            <div id="navlink">
                <button id="navlink" type="button" onMouseDown={this.props.logoutHandler}>
                    <span className="shredvidlistbutton-box">> Log Out</span>
                </button>
            </div>
        );
    }
}

export default ShredLogoutButton;