import React, { Component } from 'react';
require("!style-loader!css-loader!../css/shredburger.css");
require("!style-loader!css-loader!../css/mobile/shredburger_mobile.css");

class ShredsidebarButton extends Component {
    render() {
        var anim = "hamburger hamburger--arrowalt-r";

        if (this.props.menuVisibility) {
            anim = "hamburger hamburger--arrowalt-r is-active";
        }
        
        return (
            <button className={anim} type="button" onMouseDown={this.props.handleMouseDown}>
                <span className="hamburger-box">
                    <span className="hamburger-inner"></span>
                </span>
            </button>
        );
    }
}

export default ShredsidebarButton;