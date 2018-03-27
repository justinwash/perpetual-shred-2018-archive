import React, { Component } from 'react';
import ShredComingUp from './shredcomingup.jsx';
import FavButton from'./favbutton.jsx';
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
                <div id="vidoriginBox">
                    <div id="descriptionheader">
                        SOURCE:
                    </div>
                    <div id="vidsourcelink"><a href={jsModel.OriginUrl}>
                        <img className="ytLogo" src={'/images/yt_icon_mono_dark.png'} />  {jsModel.VideoService}</a>
                    </div>
                </div>
                <div id="favbuttonbox">
                    <div id="descriptionheader">
                    MY SHREDNESS:
                    </div>
                    <FavButton />
                </div>
                <ShredComingUp />
            </div>
        </div> )
    }
}

export default ShredSideBar;