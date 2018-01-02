import React, { Component } from 'react'
import ReactDOM from 'react-dom'
import ReactPlayer from 'react-player'
require("!style-loader!css-loader!../css/shredplayer.css");

var loaded = false;

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

    loaded() {
        loaded = true
        console.log('loaded it!')
    }
    reload() {
        console.log('trying to refresh!')
        if (loaded = true) {
            window.location.reload()
        } 
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
                            onReady={() => console.log('onReady')}
                            onStart={() => this.loaded()}
                            onPlay={() => console.log('onPlay')}
                            onPause={() => console.log('onPause')}
                            onBuffer={() => console.log('onBuffer')}
                            onEnded={() => this.reload()}
                            onError={() => console.log('onError')}
                            onProgress={() => console.log('onProgress')}
                            onDuration={() => console.log('onDuration')}
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
                            onReady={() => console.log('onReady')}
                            onStart={() => this.loaded()}
                            onPlay={() => console.log('onPlay')}
                            onPause={() => console.log('onPause')}
                            onBuffer={() => console.log('onBuffer')}
                            onEnded={() => this.reload()}
                            onError={() => console.log('onError')}
                            onProgress={() => console.log('onProgress')}
                            onDuration={() => console.log('onDuration')}
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
                        onReady={() => console.log('onReady')}
                        onStart={() => this.loaded()}
                        onPlay={() => console.log('onPlay')}
                        onPause={() => console.log('onPause')}
                        onBuffer={() => console.log('onBuffer')}
                        onEnded={() => this.reload()}
                        onError={() => console.log('onError')}
                        onProgress={() => console.log('onProgress')}
                        onDuration={() => console.log('onDuration')}
                        playing={this.state.playing}
                        
                    />
                </div>
            );
        }
    }
}

ReactDOM.render(
    <Shredplayer />,
    document.getElementById('shredplayer')
);