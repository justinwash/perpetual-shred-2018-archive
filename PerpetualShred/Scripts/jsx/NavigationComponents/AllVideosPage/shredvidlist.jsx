import React, { Component } from "react";
require("!style-loader!css-loader!../../../css/shredvidlist.css");
require("!style-loader!css-loader!../../../css/mobile/shredvidlist_mobile.css");
import axios from 'axios';
import ShredNextButton from './shrednextbutton.jsx';

class ShredVidList extends Component {
    constructor(props, context) {
        super(props, context);
        this.state = {
            vidlist: {__html: "There doesn't appear to be anything here."},
            vidSetStart: 0,
            vidSetLength: 5,
            pageNumber: 1,
            loading: false
        };

        this.getVidSubset = this.getVidSubset.bind(this);
        this.getNextSet = this.getNextSet.bind(this);
        this.getPrevSet = this.getPrevSet.bind(this);
    }
    
    componentDidMount() {
        this.getVidSubset(this.state.vidSetStart, this.state.vidSetLength);
    }
    
    getNextSet() {
        this.getVidSubset((this.state.vidSetStart + this.state.vidSetLength), this.state.vidSetLength);
        this.setState({vidSetStart: (this.state.vidSetStart + this.state.vidSetLength)});
        this.setState({pageNumber: (this.state.pageNumber + 1)});
    }
    
    getPrevSet() {
        if (this.state.vidSetStart < 1)
        {
            this.getVidSubset(0, 5);
            this.setState({pageNumber: 1});
        }
        else {
            this.getVidSubset((this.state.vidSetStart - this.state.vidSetLength), this.state.vidSetLength);
            this.setState({vidSetStart: (this.state.vidSetStart - this.state.vidSetLength)});
            this.setState({pageNumber: (this.state.pageNumber - 1)});
        }
    }

    getVidSubset(start, count) {
        this.setState({loading: true});
        
        axios.get("/Query/Fetch?subindex=" + start + "!" + count)
            .then(res => {
                const vidsubset = res.data.toString();
                this.setState({vidlist: {__html: vidsubset}});
                this.setState({loading: false});
            })
    }
    
    render() {
        var visibility = "hide";
        if (this.props.animSwitcher)
            visibility = "show";
        else visibility = "hide";
        
        if (this.state.loading)
        {
            return (
                <div id="loadingspinner" className={visibility} />
            )
        }
        else {
            return (
                <div className="vidlistcontainer">
                    <div id="shredvidlist-background" className={visibility}/>
                    <div id="shredvidlist" className={visibility}>
                        <div dangerouslySetInnerHTML={this.state.vidlist}/>
                        <div className={"nextbuttonbox"}>
                            <ShredNextButton nextHandler={this.getNextSet}
                                             buttonType={"shrednextbutton"}
                                             displayName={"NEXT"}/>
                            <div className="pagecounter">{this.state.pageNumber}</div>
                            <ShredNextButton nextHandler={this.getPrevSet}
                                             buttonType={"shredprevbutton"}
                                             displayName={"PREV"}/>
                        </div>
                    </div>
                </div>
            );
        }
    }
}

export default ShredVidList;