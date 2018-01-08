import React, { Component } from 'react';
import ReactDOM from 'react-dom';
// Import sidebar components
import ShredsidebarButton from './shredsidebarbutton.jsx';
import Shredsidebar from './shredsidebar.jsx';
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
            sidebarVisible: true,
            navOverlayVisible: false,
            allVidsVisible: false,
            sidebarWasVisible: false,
            discoverRadness: false

        };
        // Sidebar prop binds
        this.sidebarMouseDown = this.sidebarMouseDown.bind(this);
        this.toggleSidebar = this.toggleSidebar.bind(this);

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

    // Sidebar functions
    sidebarMouseDown(e) {
        this.toggleSidebar();
        e.stopPropagation();
    }

    toggleSidebar() {
        this.setState({
            sidebarVisible: !this.state.sidebarVisible
        });
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
        else {
            this.setState({
                sidebarWasVisible: false
            });
        }

        if (this.state.allVidsVisible) {
            this.setState({
                navOverlayVisible: false,
                allVidsVisible: false
            });
            if (this.state.sidebarWasVisible) {
                this.setState({
                    sidebarVisible: true
                });
            }
        }

        else {
            if (this.state.sidebarWasVisible) {
                this.setState({
                    navOverlayVisible: !this.state.navOverlayVisible,
                    allVidsVisible: false,
                    sidebarVisible: true
                });
            }
            else {
                this.setState({
                    navOverlayVisible: !this.state.navOverlayVisible,
                    allVidsVisible: false,
                    sidebarVisible: false
                });
            }
        }
    }

    // AllVids functions
    allVidsMouseDown(e) {
        this.toggleAllVids();
        e.stopPropagation();
    }

    toggleAllVids() {
        this.setState({
            allVidsVisible: !this.state.allVidsVisible,
            navOverlayVisible: false,
            sidebarVisible: false
        });
    }

    discoverRadness() {
        window.location.replace("http://perpetualshred20180102115742.azurewebsites.net/");
    }


    render() {
        return <Gamepad
            onConnect={this.connectHandler}
            onDisconnect={this.disconnectHandler}
            onRB={this.toggleSidebar}
            onLB={this.toggleNavOverlay}
            onLT={this.toggleAllVids}
            onBack={this.discoverRadness}
            >
            <div>
                <ShredsidebarButton handleMouseDown={this.sidebarMouseDown}
                                    menuVisibility={this.state.sidebarVisible}/>
                <Shredsidebar handleMouseDown={this.sidebarMouseDown}
                              menuVisibility={this.state.sidebarVisible}/>

                <ShredNavButton handleMouseDown={this.navOverlayMouseDown}
                                menuVisibility={this.state.navOverlayVisible}/>
                <ShredNavOverlay handleMouseDown={this.navOverlayMouseDown}
                                 menuVisibility={this.state.navOverlayVisible}
                                 allVidsMouseDown={this.allVidsMouseDown} discoverRadness={this.discoverRadness}/>

                <ShredVidList handleMouseDown={this.allVidsMouseDown}
                              menuVisibility={this.state.allVidsVisible}/>
            </div>
        </Gamepad>;
    }
}

ReactDOM.render(
    <ShredUI />,
    document.getElementById("shredui")
);