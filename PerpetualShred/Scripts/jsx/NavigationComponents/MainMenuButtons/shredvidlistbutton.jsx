import React, { Component } from 'react';

class ShredVidListButton extends Component {
    render() {
        return (
            <div id="navlink">
                <button id="navlink" type="button" onMouseDown={this.props.allVidsHandler}>
                    <span className="shredvidlistbutton-box">All Videos</span>
                </button>
            </div>
        );
    }
}

export default ShredVidListButton;