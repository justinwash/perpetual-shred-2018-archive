import React, { Component } from "react";
require("!style-loader!css-loader!../../../css/shredloginpage.css");
require("!style-loader!css-loader!../../../css/mobile/shredloginpage_mobile.css");
import axios from 'axios';

class ShredLoginPage extends Component {
    constructor(props, context) {
        super(props, context);
        this.state = {
            loginView: {__html: "There doesn't appear to be anything here."}
        };

        this.getLoginView = this.getLoginView.bind(this);
    }
    
    componentDidMount() {
        this.getLoginView();
    }

    getLoginView() {
        axios.get("/Account/Login")
            .then(res => {
                const loginHtml = res.data.toString();
                this.setState({loginView: {__html: loginHtml}});
            })
    }
    
    render() {
        
        var visibility = "hide"; // change this back to hide when finished!
        if (this.props.animSwitcher)
            visibility = "show";
        else visibility = "hide";
        
            return (
                <div className="vidlistcontainer">
                    <div id="shredvidlist-background" className={visibility}/>
                    <div id="shredvidlist" className={visibility}>
                        <div dangerouslySetInnerHTML={this.state.loginView}/>
                    </div>
                </div>
            );
        }
    
}

export default ShredLoginPage;