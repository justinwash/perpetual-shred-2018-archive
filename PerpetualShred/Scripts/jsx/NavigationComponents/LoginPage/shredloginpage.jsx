import React, { Component } from "react";
require("!style-loader!css-loader!../../../css/shredloginpage.css");
require("!style-loader!css-loader!../../../css/mobile/shredloginpage_mobile.css");
import axios from 'axios';

class ShredLoginPage extends Component {
    constructor(props, context) {
        super(props, context);
        this.state = {
        };
    }
    
    render() {
        var visibility = "hide";
        if (this.props.animSwitcher)
            visibility = "show";
        else visibility = "hide";
        
            return (
                <div className="vidlistcontainer">
                    <div id="shredvidlist-background" className={visibility}/>
                    <div id="shredvidlist" className={visibility}>
                        <div dangerouslySetInnerHTML={this.props.viewHtml}/>
                    </div>
                </div>
            );
        }
    
}

export default ShredLoginPage;