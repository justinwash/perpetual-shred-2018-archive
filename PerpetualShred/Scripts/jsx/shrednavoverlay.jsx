import React, { Component } from "react";
require("!style-loader!css-loader!../css/shrednavoverlay.css");

class ShredNavOverlay extends Component {
    render() {
        var visibility = "hide";

        if (this.props.menuVisibility) {
            visibility = "show";
        }

        return (
            <div>
                <div id="shrednavoverlay-background" className={visibility} />
                <div id="shrednavoverlay-titlebar"
                    onMouseDown={this.props.handleMouseDown}
                    className={visibility}>
                </div>
                <div id="shrednavoverlay" className={visibility}>
                    <div id="navlink-list">
                    <div id="navlink">
                        ∞ Discover Radness
                    </div>
                    <div id="navlink">
                            <button id="navlink" type="button" onMouseDown={this.props.allVidsMouseDown}>
                                <span className="shredvidlistbutton-box">> All Videos</span>
                            </button>
                    </div>
                    <div id="navlink">
                        > Who We Are
                    </div>
                </div>
                </div>
            </div>
        );
    }
}

export default ShredNavOverlay;