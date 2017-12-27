import React, { Component } from "react";
require("!style-loader!css-loader!../css/shredvidlist.css");

class ShredVidList extends Component {
    render() {
        var visibility = "hide";

        if (this.props.menuVisibility) {
            visibility = "show";
        }

        return (
            <div>
                <div id="shredvidlist-background" className={visibility} />
                <div id="shredvidlist" className={visibility}>
                    {jsVidList}
                </div>
            </div>
        );
    }
}

export default ShredVidList;