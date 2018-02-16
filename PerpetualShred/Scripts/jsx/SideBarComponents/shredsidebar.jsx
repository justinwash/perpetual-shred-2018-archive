import React, { Component } from 'react';
import ShredComingUp from './shredcomingup.jsx'
require('!style-loader!css-loader!../../css/shredsidebar.css');
require('!style-loader!css-loader!../../css/mobile/shredsidebar_mobile.css');

class ShredSideBar extends Component {
    render() {
        var visibility = "show";

        if (this.props.animSwitcher)
            visibility = "show";
        else visibility = "hide";

        return (
        <div className="menucontainer">
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
                        read more at <a href={jsModel.OriginUrl}>{jsModel.VideoService}.com</a>
                    </div>
                
                <ShredComingUp />
            </div>
        </div> )
    }
}

export default ShredSideBar;