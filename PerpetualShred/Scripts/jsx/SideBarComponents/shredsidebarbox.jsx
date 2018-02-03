import React, { Component } from "react";
import ReactDOM from "react-dom";
import ShredSideBar from '../SideBarComponents/shredsidebar.jsx';
import ShredSideBarButton from '../SideBarComponents/shredsidebarbutton.jsx';

class ShredSideBarBox extends Component {
    constructor(props, context) {
        super(props, context);
        this.state = {
            active: true,
        };
        
        this.toggle = this.toggle.bind(this);
    }
    
    toggle() {
        this.setState({ active: !this.state.active});
    }

    render() {
        return (
            <div>
                <ShredSideBarButton toggleHandler={this.toggle} animSwitcher={this.state.active}/>
                <ShredSideBar toggleHandler={this.toggle} animSwitcher={this.state.active}/>
            </div>
        )
    }
}
    
ReactDOM.render(<ShredSideBarBox />,
    document.getElementById('shredsidebarbox')
);


