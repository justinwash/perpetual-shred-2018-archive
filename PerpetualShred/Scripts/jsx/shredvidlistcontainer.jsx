import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import ShredVidListButton from './shredvidlistbutton.jsx'
import ShredVidList from './shredvidlist.jsx'

class ShredVidListContainer extends Component {
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
                <ShredVidList handleMouseDown={this.handleMouseDown}
                    menuVisibility={this.state.visible} />
            </div>
        );
    }
}

ReactDOM.render(
    <ShredVidListContainer />,
    document.getElementById("shredvidlistcontainer")
);