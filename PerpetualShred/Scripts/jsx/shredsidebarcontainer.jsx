import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import ShredsidebarButton from './shredsidebarbutton.jsx'
import Shredsidebar from './shredsidebar.jsx'

class ShredSideBarContainer extends Component {
    constructor(props, context) {
        super(props, context);

        this.state = {
            visible: true
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
                <ShredsidebarButton handleMouseDown={this.handleMouseDown} 
                    menuVisibility={this.state.visible}/>
                <Shredsidebar handleMouseDown={this.handleMouseDown}
                    menuVisibility={this.state.visible} />
            </div>
        );
    }
}

ReactDOM.render(
    <ShredSideBarContainer />,
    document.getElementById("shredsidebarcontainer")
);