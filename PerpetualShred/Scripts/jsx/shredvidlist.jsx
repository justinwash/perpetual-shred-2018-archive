import React, { Component } from "react";
import ReactDOM from "react-dom";
require("!style-loader!css-loader!../css/shredvidlist.css");
require("!style-loader!css-loader!../css/mobile/shredvidlist_mobile.css");
import axios from 'axios';
import ShredNextButton from './shrednextbutton.jsx';

class ShredVidList extends Component {
    constructor(props, context) {
        super(props, context);
        this.state = {
            vidlist: {__html: "There doesn't appear to be anything here."}
        };

        this.getVidSubset = this.getVidSubset.bind(this);
        this.getNextTen = this.getNextTen.bind(this);
    }
    
    
    componentDidMount() {
        this.getVidSubset(0, 10);
    }
    
    getNextTen() {
        this.getVidSubset(10, 20);
    }

    getVidSubset(start, count) {
        axios.get("/Query/Fetch?subindex=" + start + "!" + count)
            .then(res => {
                const vidsubset = res.data.toString();
                this.setState({vidlist: {__html: vidsubset}});
            })
    }
    
    render() {
        var visibility = "hide";

        if (this.props.animSwitcher)
            visibility = "show";
        else visibility = "hide";
        
        return (
            <div className="vidlistcontainer">
                <div id="shredvidlist-background" className={visibility} />
                <div id="shredvidlist" className={visibility}>
                    <div dangerouslySetInnerHTML={ this.state.vidlist } />
                    <ShredNextButton nextHandler={this.getNextTen} />
                </div>
            </div>
        );
    }
}

export default ShredVidList;