import React, { Component } from 'react';
require("!style-loader!css-loader!../css/shrednavbutton.css");


class ShredNavButton extends Component {
    render() {
        var anim = "dock";

        if (this.props.menuVisibility) {
            anim = "float";
        }
        
        return (
            <button id="shrednavbutton" className={anim} type="button" onMouseDown={this.props.handleMouseDown}>
                <span className="shrednavbutton-box"></span>
            </button>
        );
    }
}

export default ShredNavButton;