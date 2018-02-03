import React, { Component } from 'react';
require("!style-loader!css-loader!../../css/shrednavbutton.css");
require("!style-loader!css-loader!../../css/mobile/shrednavbutton_mobile.css");


class ShredNavUIButton extends Component {
    render() {
        var anim = "dock";

        if (this.props.animSwitcher)
            anim = "float";
        else anim = "dock";
        
        return (
            <button id="shrednavbutton" className={anim} type="button" onMouseDown={this.props.toggleHandler}>
                <span className="shrednavbutton-box" />
            </button>
        );
    }
}

export default ShredNavUIButton;