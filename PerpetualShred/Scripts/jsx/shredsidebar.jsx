import React, { Component } from "react";
require("!style-loader!css-loader!../css/shredsidebar.css");

class Shredsidebar extends Component {
    
    render() {
        let visibility = "hide";

        if (this.props.menuVisibility) {
            visibility = "show";
        }

        return <div>
            <div id="flyoutMenuBackground" className={visibility}/>
            <div id="flyoutMenu" className={visibility}>
                <div id="vidtitle">
                    {jsModel.Title}
                </div>
                <div id="descriptionheader">
                    DESCRIPTION:
                </div>
                <div id="vidsynopsis">
                    {jsModel.Synopsis}
                </div>
                <div id="vidoriginlink">
                    read more at {jsModel.VideoService}.com
                </div>
            </div>
        </div>;
    }
}

export default Shredsidebar;