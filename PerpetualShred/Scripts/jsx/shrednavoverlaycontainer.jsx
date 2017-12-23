import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import ShredNavButton from './shrednavbutton.jsx'
import ShredNavOverlay from './shrednavoverlay.jsx'

class ShredNavOverlayContainer extends Component {
    constructor(props, context) {
        super(props, context);

        this.state = {
            visible: false
        };

        this.handleMouseDown = this.handleMouseDown.bind(this);
        this.toggleMenu = this.toggleMenu.bind(this);
    }

    handleMouseDown(e) {
        this.toggleMenu();

        console.log("clicked");
        e.stopPropagation();
    }

    toggleMenu() {
        this.setState({
            visible: !this.state.visible
        });
    }

    render() {
        return (
            <div>
                <ShredNavButton handleMouseDown={this.handleMouseDown} 
                    menuVisibility={this.state.visible}/>
                <ShredNavOverlay handleMouseDown={this.handleMouseDown}
                    menuVisibility={this.state.visible} />
            </div>
        );
    }
}

ReactDOM.render(
    <ShredNavOverlayContainer />,
    document.getElementById("shrednavoverlaycontainer")
);