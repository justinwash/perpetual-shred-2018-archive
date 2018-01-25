import React, { Component } from "react";
import ReactDOM from "react-dom";
require("!style-loader!css-loader!../css/shredvidlist.css");
require("!style-loader!css-loader!../css/mobile/shredvidlist_mobile.css");

class ShredVidList extends Component {
    render() {
        var visibility = "hide";

        if (this.props.animSwitcher)
            visibility = "show";
        else visibility = "hide";

        function htmlDecode(input) {
            var e = document.createElement('div');
            e.innerHTML = input;
            return e.childNodes.length === 0 ? "" : e.childNodes[0].nodeValue;
        }
        
        function removeBrTag(text) {
            text = text.replace(/[<]br[^>]*[>]/gi,"");
            text = text.replace(/[<]br[^>] *[>]/gi,"");
            return text;
        }
        
        return (
            <div className="vidlistcontainer">
                <div id="shredvidlist-background" className={visibility} />
                <div id="shredvidlist" className={visibility}>
                    <div dangerouslySetInnerHTML={{__html: removeBrTag(htmlDecode(jsVidList)) }} />
                </div>
            </div>
        );
    }
}

export default ShredVidList;