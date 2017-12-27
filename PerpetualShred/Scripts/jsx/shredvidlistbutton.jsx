import React, { Component } from 'react';
require("!style-loader!css-loader!../css/shredvidlistbutton.css");


class ShredVidListButton extends Component {
    render() {
        
        return (
            <button id="shredvidlistbutton" type="button" onMouseDown={this.props.handleMouseDown}>
                <span className="shredvidlistbutton-box">∞ Discover Radness</span>
            </button>
        );
    }
}

export default ShredVidListButton;