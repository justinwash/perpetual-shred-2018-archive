import React, { Component } from "react";
import ReactDOM from "react-dom";
import ShredNavOverlay from './shrednavoverlay.jsx';
import ShredNavUIButton from './shrednavuibutton.jsx';

class ShredNavOverlayBox extends Component {
    constructor(props, context) {
        super(props, context);
        this.state = {
            navmenuactive: false,
            allvidspageactive: false,
            loginpageactive: false
        };

        this.toggle = this.toggle.bind(this);
        this.allVidsPressed = this.allVidsPressed.bind(this);
        this.loginPressed = this.loginPressed.bind(this);
    }

    toggle() {
        if (this.state.allvidspageactive || this.state.loginpageactive)
        {
            this.setState({ allvidspageactive: false });
            this.setState({ loginpageactive: false });
        }
        this.setState({ navmenuactive: !this.state.navmenuactive});
    }
    
    allVidsPressed() {
        this.setState({ navmenuactive: false, loginpageactive: false, allvidspageactive: true });
    }
    
    loginPressed() {
        this.setState({ navmenuactive: false, allvidspageactive: false, loginpageactive: true });
    }

    render() {
        return (
            <div>
                <ShredNavUIButton toggleHandler={this.toggle} 
                                animSwitcher={this.state.navmenuactive}/>
                
                <ShredNavOverlay toggleHandler={this.toggle} 
                                 allVidsHandler={this.allVidsPressed}
                                 vidPageAnimSwitcher={this.state.allvidspageactive}
                                 loginPageHandler={this.loginPressed}
                                 loginPageAnimSwitcher={this.state.loginpageactive}
                                 navMenuAnimSwitcher={this.state.navmenuactive}/>
            </div>
        )
    }
}

ReactDOM.render(<ShredNavOverlayBox />,
    document.getElementById('shrednavoverlaybox')
);