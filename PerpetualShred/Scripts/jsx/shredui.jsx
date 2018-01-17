import React, { Component } from 'react';
import ReactDOM from 'react-dom';

// Import nav overlay components
import ShredNavButton from './shrednavbutton.jsx';
import ShredNavOverlay from './shrednavoverlay.jsx';
// Import 'all vids' page
import ShredVidList from './shredvidlist.jsx';
// Import Gamepad support component
import Gamepad from 'react-gamepad';

class ShredUI extends Component {
    constructor(props, context) {
        super(props, context);

        this.state = {
            navOverlayVisible: false,
            allVidsVisible: false,
            discoverRadness: false

        };
        

        // NavOverlay prop binds
        this.navOverlayMouseDown = this.navOverlayMouseDown.bind(this);
        this.toggleNavOverlay = this.toggleNavOverlay.bind(this);

        // AllVids prop binds
        this.allVidsMouseDown = this.allVidsMouseDown.bind(this);
        this.toggleAllVids = this.toggleAllVids.bind(this);

        // Discover Radness prop bind
        this.discoverRadness = this.discoverRadness.bind(this);
        
    }
    
    //Gamepad functionality
    connectHandler(gamepadIndex) {
        console.log(`Gamepad ${gamepadIndex} connected !`)
    }

    disconnectHandler(gamepadIndex) {
        console.log(`Gamepad ${gamepadIndex} disconnected !`)
    }
    

    // NavOverlay functions
    navOverlayMouseDown(e) {
        this.toggleNavOverlay();
        e.stopPropagation();
    }

    toggleNavOverlay() {
        if (this.state.sidebarVisible) {
            this.setState({
                sidebarVisible: false,
                sidebarWasVisible: true
            });
        }
        

        if (this.state.allVidsVisible) {
            this.setState({
                navOverlayVisible: false,
                allVidsVisible: false
            });
            
        }

        
            else {
                this.setState({
                    navOverlayVisible: !this.state.navOverlayVisible,
                    allVidsVisible: false
                });
            }
        }
    }

    // AllVids functions
    allVidsMouseDown(e); {
        this.toggleAllVids();
        e.stopPropagation();
    }

    toggleAllVids(); {
        this.setState({
            allVidsVisible: !this.state.allVidsVisible,
            navOverlayVisible: false
        });
    }

    discoverRadness(); {
        window.location.replace("http://www.perpetualshred.com/");
    }


    render(); {
        
    }
}

ReactDOM.render(
    <ShredUI />,
    document.getElementById("shredui")
);