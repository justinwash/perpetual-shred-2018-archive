import React, { Component } from "react";
import ReactDOM from "react-dom";
import ShredVidList from './shredvidlist.jsx';
import ShredVidListButton from './shredvidlistbutton.jsx';

class ShredVidListBox extends Component {
    constructor(props, context) {
        super(props, context);
        this.state = {
            active: false,
        };

        this.toggle = this.toggle.bind(this);
    }

    toggle() {
        this.setState({ active: !this.state.active});
    }

    render() {
        return (
            <div>
                <ShredVidListButton toggleHandler={this.toggle} oldMenuMover={this.props.toggleHandler} animSwitcher={this.state.active}/>
                <ShredVidList toggleHandler={this.toggle} animSwitcher={this.state.active}/>
            </div>
        )
    }
}

export default ShredVidListBox;