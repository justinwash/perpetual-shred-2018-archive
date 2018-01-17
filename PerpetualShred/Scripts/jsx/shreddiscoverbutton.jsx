import React, { Component } from 'react';

class ShredDiscoverButton extends Component {
    render() {

        function discoverRadness(){
            window.location.replace("http://www.perpetualshred.com/");
        }
        
        return (
            <div id="navlink">
                <button id="navlink" type="button" onMouseDown={this.discoverRadness}>
                    <span className="shredvidlistbutton-box">∞ Discover Radness</span>
                </button>
            </div>
        );
    }
}

export default ShredDiscoverButton;