import React, { Component } from "react";
import ShredDiscoverButton from "./MainMenuButtons/shreddiscoverbutton.jsx";
import ShredVidListBox from "./AllVideosPage/shredvidlistbox.jsx";
import ShredInfoButton from "./MainMenuButtons/shredinfobutton.jsx";
import ShredLoginBox from "./LoginPage/shredloginbox.jsx";

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
                        <ShredLoginBox loginPageHandler={this.props.loginPageHandler}
                                        animSwitcher={this.props.loginPageAnimSwitcher} />
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