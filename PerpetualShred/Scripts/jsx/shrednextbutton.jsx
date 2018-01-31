import React, { Component } from 'react';
require("!style-loader!css-loader!../css/shrednavbutton.css");
require("!style-loader!css-loader!../css/mobile/shrednavbutton_mobile.css");


class ShredNextButton extends Component {
    render() {
        
        return (
            <button className="vidOrigin" type="button" onMouseDown={this.props.nextHandler}>
                NEXT 10 SHREDITS
            </button>
        );
    }
}

export default ShredNextButton;