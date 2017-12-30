import React, { Component } from "react";
require("!style-loader!css-loader!../css/shredvidlist.css");

class ShredVidList extends Component {
    render() {
        var visibility = "hide";

        if (this.props.menuVisibility) {
            visibility = "show";
        }

        function htmlDecode(input) {
            var e = document.createElement('div');
            e.innerHTML = input;
            return e.childNodes.length === 0 ? "" : e.childNodes[0].nodeValue;
        }
        
        return (
            <div>
                <div id="shredvidlist-background" className={visibility} />
                <div id="shredvidlist" className={visibility}>
                    <div dangerouslySetInnerHTML={{__html: htmlDecode(jsVidList) }} />
                </div>
            </div>
        );
    }
}

export default ShredVidList;