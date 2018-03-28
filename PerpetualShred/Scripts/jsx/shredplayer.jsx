import React, { Component } from 'react'
import ReactDOM from 'react-dom'
import ReactPlayer from 'react-player'
require("!style-loader!css-loader!../css/shredplayer.css");
require("!style-loader!css-loader!../css/mobile/shredplayer_mobile.css");

var loaded = false;

class ShredPlayer extends React.Component {

    constructor(props) {
        super(props);
        this.onClickFullscreen = this.onClickFullscreen.bind(this);
        this.state = {
            playing: true
        }
    }
    onClickFullscreen() {
        screenfull.request(ReactDOM.findDOMNode(this.refs.player))
    }

    loaded() {
        loaded = true;
        console.log('loaded it!')
    }
    reload() {
        console.log('trying to refresh!');
        if (loaded = true) {
            window.location.replace("/")
        } 
    }
    render() {
        if (jsModel.VideoService === "PinkBike") {
            if (JSON.parse(jsModel.SourceList)[3] != null) {
                return (
                    <div id="pbcontainer">
                        <ReactPlayer ref='player'
                            url={
                                JSON.parse(jsModel.SourceList)[3]
                            }
                            onStart={() => this.loaded()}
                            onEnded={() => this.reload()}
                            playing={this.state.playing}
                            width=""
                            height=""
                            />
                    </div>
                );
            }
            else {
                return (
                    <div id="pbcontainer" >
                        <ReactPlayer ref='player'
                            url={
                                JSON.parse(jsModel.SourceList)[2]
                            }
                            onStart={() => this.loaded()}
                            onEnded={() => this.reload()}
                            playing={this.state.playing}
                            width=""
                            height=""
                        />
                    </div>
                );
            }
        }

        else {
            return (
                <div>
                    <ReactPlayer ref='player'
                        url={
                            jsModel.PlayerUrl
                        }
                        playing={this.state.playing}
                        width='100%'
                        height='100%'
                        onStart={() => this.loaded()}
                        onEnded={() => this.reload()}
                        playing={this.state.playing}
                        
                    />
                </div>
            );
        }
    }
}

ReactDOM.render(
    <ShredPlayer />,
    document.getElementById('shredplayer')
);