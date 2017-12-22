import React, { Component } from 'react';
require("!style-loader!css-loader!../css/shrednavbutton.css");

class ShrednavButton extends Component {
    render() {
        var anim = "shrednavbutton dock";

        if (this.props.menuVisibility) {
            anim = "shrednavbutton float";
        }
        
        return (
            <button className={anim} type="button" onMouseDown={this.props.handleMouseDown}>
            </button>
        );
    }
}

export default ShrednavButton;