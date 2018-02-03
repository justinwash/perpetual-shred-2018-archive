import React, { Component } from "react";
import ShredDiscoverButton from "./shredoverlaynavbuttons/shreddiscoverbutton.jsx";
import ShredVidListBox from "./shredvidlist/shredvidlistbox.jsx";
import ShredInfoButton from "./shredoverlaynavbuttons/shredinfobutton.jsx";
require("!style-loader!css-loader!../../css/shrednavoverlay.css");
require("!style-loader!css-loader!../../css/mobile/shrednavoverlay_mobile.css");

class ShredNavOverlay extends Component {
    render() {
        var visibility = "hide";

        if (this.props.navMenuAnimSwitcher)
            visibility = "show";
        else visibility = "hide";
        
        return (
            <div>
                <div id="shrednavoverlay-background" className={visibility} />
                <div id="shrednavoverlay-titlebar"
                    className={visibility}>
                </div>
                <div id="shrednavoverlay" className={visibility}>
                    <div id="navlink-list">
                        <ShredDiscoverButton/>
                        <ShredVidListBox allVidsHandler={this.props.allVidsHandler} 
                                         animSwitcher={this.props.vidPageAnimSwitcher} />
                        <ShredInfoButton/>
                    </div>
                </div>
            </div>
        );
    }
}

export default ShredNavOverlay;