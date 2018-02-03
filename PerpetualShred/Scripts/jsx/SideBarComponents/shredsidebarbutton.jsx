import React, { Component } from 'react';
require("!style-loader!css-loader!../../css/shredburger.css");
require("!style-loader!css-loader!../../css/mobile/shredburger_mobile.css");

class ShredSideBarButton extends Component {
    render() {
        
        var anim = "hamburger hamburger--arrowalt-r";
        
        if (this.props.animSwitcher) {
            anim = "hamburger hamburger--arrowalt-r is-active";
        }
        else anim = "hamburger hamburger--arrowalt-r";
        
        return (
            <button className={anim} type="button" onMouseDown={this.props.toggleHandler}>
                <span className="hamburger-box">
                    <span className="hamburger-inner" />
                </span>
            </button>
        );
    }
}

export default ShredSideBarButton;