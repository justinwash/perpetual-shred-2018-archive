import React, { Component } from 'react';

class ShredDiscoverButton extends Component {

    discoverRadness(){
        window.location.replace("/");
    }

    render() {
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