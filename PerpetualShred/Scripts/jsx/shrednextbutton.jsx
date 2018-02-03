import React, { Component } from 'react';
require("!style-loader!css-loader!../css/shrednavbutton.css");
require("!style-loader!css-loader!../css/mobile/shrednavbutton_mobile.css");


class ShredNextButton extends Component {
    render() {
        
        return (
            <button className={this.props.buttonType} type="button" onMouseDown={this.props.nextHandler}>
                {this.props.displayName}
            </button>
        );
    }
}

export default ShredNextButton;