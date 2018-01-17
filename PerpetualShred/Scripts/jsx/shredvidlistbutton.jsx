import React, { Component } from 'react';

class ShredVidListButton extends Component {
    render() {
        var visibility = "hide";

        function vidListVisibility() {
            if (visibility === "hide"){
                visibility = "show";
            }
            if (visibility === "show"){
                visibility = "hide";
            }
        }
        
        return (
            <div id="navlink">
                <button id="navlink" type="button" onMouseDown={this.vidListVisibility}>
                    <span className="shredvidlistbutton-box">> All Videos</span>
                </button>
            </div>
        );
    }
}

export default ShredVidListButton;