import React, { Component } from 'react';

class ShredInfoButton extends Component {
    render() {
        var visibility = "hide";

        function infoVisibility() {
            if (visibility === "hide"){
                visibility = "show";
            }
            if (visibility === "show"){
                visibility = "hide";
            }
        }
        
        return (
            <div id="navlink">
                <button id="navlink" type="button" onMouseDown={this.infoVisibility}>
                    <span className="shredvidlistbutton-box">> Who We Are</span>
                </button>
            </div>
        );
    }
}

export default ShredInfoButton;