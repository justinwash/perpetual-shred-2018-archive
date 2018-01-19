import React, { Component } from "react";
import ShredDiscoverButton from "./shreddiscoverbutton.jsx";
import ShredVidListButton from "./shredvidlistbutton.jsx";
import ShredInfoButton from "./shredinfobutton.jsx";
require("!style-loader!css-loader!../css/shrednavoverlay.css");

class ShredNavOverlay extends Component {
    render() {
        var visibility = "hide";

        if (this.props.animSwitcher)
            visibility = "show";
        else visibility = "hide";
        
        return (
            <div>
                <div id="shrednavoverlay-background" className={visibility} />
                <div id="shrednavoverlay-titlebar"
                    onMouseDown={this.props.toggleHandler}
                    className={visibility}>
                </div>
                <div id="shrednavoverlay" className={visibility}>
                    <div id="navlink-list">
                        <ShredDiscoverButton/>
                        <ShredVidListButton />
                        <ShredInfoButton/>
                    </div>
                </div>
            </div>
        );
    }
}

export default ShredNavOverlay;