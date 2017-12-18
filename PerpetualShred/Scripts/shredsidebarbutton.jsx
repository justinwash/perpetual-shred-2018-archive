import React, { Component } from 'react';

class ShredsidebarButton extends Component {
    render() {
        return (
            <button id="infoButton"
                onMouseDown={this.props.handleMouseDown}></button>
        );
    }
}

export default ShredsidebarButton;