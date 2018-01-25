import React, { Component } from "react";
import ReactDOM from "react-dom";
import ShredVidList from './shredvidlist.jsx';
import ShredVidListButton from './shredvidlistbutton.jsx';

class ShredVidListBox extends Component {
    render() {
        return (
            <div>
                <ShredVidListButton allVidsHandler={this.props.allVidsHandler} 
                                    animSwitcher={this.props.animSwitcher}/>
                <ShredVidList animSwitcher={this.props.animSwitcher}/>
            </div>
        )
    }
}

export default ShredVidListBox;