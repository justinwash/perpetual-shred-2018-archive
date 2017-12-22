import React, { Component } from 'react'
import ReactDOM from 'react-dom'
import ReactPlayer from 'react-player'
require("!style-loader!css-loader!../css/shredplayer.css");

class Shredplayer extends React.Component {

    constructor(props) {
        super(props)
        this.onClickFullscreen = this.onClickFullscreen.bind(this)
        this.state = {
            playing: true
        }
    }
    onClickFullscreen() {
        screenfull.request(ReactDOM.findDOMNode(this.refs.player))
    }
    render() {
        if (jsModel.VideoService == "PinkBike") {
            if (JSON.parse(jsModel.SourceList)[3] != null) {
                return (
                    <div id="pbcontainer">
                        <ReactPlayer ref='player'
                            url={
                                JSON.parse(jsModel.SourceList)[3]
                            }
                            
                            playing={this.state.playing}
                            width=""
                            height=""
                            />
                    </div>
                );
            }
            else {
                return (
                    <div id="pbcontainer">
                        <ReactPlayer ref='player'
                            url={
                                JSON.parse(jsModel.SourceList)[2]
                            }
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
                        controls='false'
                        width='100%'
                        height='100%' />
                </div>
            );
        }
    }
}

ReactDOM.render(
    <Shredplayer />,
    document.getElementById('shredplayer')
);