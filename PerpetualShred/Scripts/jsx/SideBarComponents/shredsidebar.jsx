import React, { Component } from 'react';
import ShredComingUp from './shredcomingup.jsx';
import FontAwesomeIcon from '@fortawesome/react-fontawesome';
import fontawesome from '@fortawesome/fontawesome';
import brands from '@fortawesome/fontawesome-free-brands';
require('!style-loader!css-loader!../../css/shredsidebar.css');
require('!style-loader!css-loader!../../css/mobile/shredsidebar_mobile.css');

fontawesome.library.add(brands);

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
                    <div id="vidsourcelink">
                        <FontAwesomeIcon icon={["fab", "youtube"]} /> &nbsp; <a href={jsModel.OriginUrl}>{jsModel.VideoService}</a>
                    </div>
                </div>
                
                <ShredComingUp />
            </div>
        </div> )
    }
}

export default ShredSideBar;