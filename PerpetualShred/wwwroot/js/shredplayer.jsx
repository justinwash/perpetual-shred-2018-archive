class App extends React.Component {

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
        return (
            <div>
                <ReactPlayer ref='player'
                    url={
                        jsModel.PlayerUrl
                    }
                    playing={this.state.playing}
                    width='100%'
                    height='100%' />
                <button onClick={() => this.setState({ playing: true })}>Play</button>
                <button onClick={() => this.setState({ playing: false })}>Pause</button>
                <button onClick={this.onClickFullscreen}>Fullscreen</button>
            </div>
        );
    }
}

ReactDOM.render(
    <App />,
    document.getElementById('shredplayer')
);