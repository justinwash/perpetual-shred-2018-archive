import React, { Component } from "react";
import ReactDOM from "react-dom";
import ShredNavOverlay from './shrednavoverlay.jsx';
import ShredNavButton from './shrednavbutton.jsx';

class ShredNavOverlayBox extends Component {
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
                <ShredNavButton toggleHandler={this.toggle} animSwitcher={this.state.active}/>
                <ShredNavOverlay toggleHandler={this.toggle} animSwitcher={this.state.active}/>
            </div>
        )
    }
}

ReactDOM.render(<ShredNavOverlayBox />,
    document.getElementById('shrednavoverlaybox')
);