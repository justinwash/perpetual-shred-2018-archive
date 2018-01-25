import React, { Component } from 'react';

class ShredVidListButton extends Component {
    render() {
        return (
            <div id="navlink">
                <button id="navlink" type="button" onMouseDown={this.props.toggleHandler}>
                    <span className="shredvidlistbutton-box" onMouseDown={this.props.oldMenuMover}>> All Videos</span>
                </button>
            </div>
        );
    }
}

export default ShredVidListButton;