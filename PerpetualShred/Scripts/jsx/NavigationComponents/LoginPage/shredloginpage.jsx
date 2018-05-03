import React, { Component } from "react";
require("!style-loader!css-loader!../../../css/shredloginpage.css");
require("!style-loader!css-loader!../../../css/mobile/shredloginpage_mobile.css");
import FavsPage from '../../AccountComponents/Favorites/FavsPage.jsx';

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
        
        var regVisibility = "regbuttonbox-hide";
        if (this.props.regToggle) 
            regVisibility = "regbuttonbox";
        else regVisibility = "regbuttonbox-hide";
        
        if (this.props.isLoggedIn){
            return (
                <div className="vidlistcontainer">
                    <div id="shredvidlist-background" className={visibility}/>
                    <div id="shredvidlist" className={visibility}>
                        <FavsPage />
                        <div className={regVisibility}>
                            <button type="button" onMouseDown={this.props.getLoginView}>
                                <span className="registerbutton">Log In</span>
                            </button>
                            <button type="button" onMouseDown={this.props.getRegView}>
                                <span className="registerbutton">Register</span>
                            </button>
                        </div>
                    </div>
                </div>
            );
        } 
        else {
            return (
                <div className="vidlistcontainer">
                    <div id="shredvidlist-background" className={visibility}/>
                    <div id="shredvidlist" className={visibility}>
                        <div dangerouslySetInnerHTML={this.props.viewHtml}/>
                        <div className={regVisibility}>
                            <button type="button" onMouseDown={this.props.getLoginView}>
                                <span className="registerbutton">Log In</span>
                            </button>
                            <button type="button" onMouseDown={this.props.getRegView}>
                                <span className="registerbutton">Register</span>
                            </button>
                        </div>
                    </div>
                </div>
            );
        }
    }
    
}

export default ShredLoginPage;