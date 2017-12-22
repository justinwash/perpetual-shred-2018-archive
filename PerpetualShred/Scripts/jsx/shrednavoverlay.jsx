import React, { Component } from "react";
require("!style-loader!css-loader!../css/shrednavoverlay.css");

class Shrednavoverlay extends Component {
    render() {
        var visibility = "hide";

        if (this.props.menuVisibility) {
            visibility = "show";
        }

        return (
            <div>
                <div id="shrednavoverlay"
                    onMouseDown={this.props.handleMouseDown}
                    className={visibility}>
                </div>
            </div>
        );
    }
}

export default Shrednavoverlay;