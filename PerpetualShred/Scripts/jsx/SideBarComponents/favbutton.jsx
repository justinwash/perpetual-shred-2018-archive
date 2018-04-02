import React, { Component } from 'react';
import axios from "axios/index";

class FavButton extends Component {
    constructor(props) {
        super(props);
        this.state = {
            videoAdded: null,
            error: null,
            isLoggedIn: null,
            loading: null,
            viewHtml: null
        };
        this.addFav = this.addFav.bind(this);
        this.getLoginStatus = this.getLoginStatus.bind(this);
        this.getLoginView = this.getLoginView.bind(this);
    }
    
    componentDidMount() {
        this.getLoginStatus();
    }
    
    addFav(){
        axios.get("/Account/AddFav?vidUrl=" + jsModel.PlayerUrl)
            .then(res => {
                const addResult = res.data;
                this.setState({ videoAdded: addResult });
                if (!addResult){
                    this.setState( { error: true });
                } 
            })   
    }

    getLoginStatus() {
        this.setState({ loading: true });
        axios.get("/Account/IsLoggedIn")
            .then(res => {
                const loginStatus = res.data;
                this.setState({ isLoggedIn: loginStatus, loading: false });
            })
        
    }

    getLoginView() {
        this.setState({ loading: true });
        axios.get("/Account/Login")
            .then(res => {
                const loginHtml = res.data.toString();
                this.setState({ viewHtml: {__html: loginHtml, loading: false} });
            })
    }
    
    render() {
        if (this.state.error) {
            return (
                <div>
                    <button id="favbutton" type="button">
                        <span className="shredvidlistbutton-box"><img className="hornicon" src={'/images/horns.png'} /> Error :(</span>
                    </button>
                </div>
            )
        }
        if (this.state.loading) {
            return (
                <div>
                    <button id="favbutton" type="button">
                        <span className="shredvidlistbutton-box"><img className="hornicon" src={'/images/horns.png'} />  Please wait...</span>
                    </button>
                </div>
            )
        }
        if (!this.state.isLoggedIn) {
            return (
                <div>
                    <button id="favbutton" type="button" onMouseDown={this.getLoginView}>
                        <span className="shredvidlistbutton-box"><img className="hornicon" src={'/images/horns.png'} />  Log in to save videos</span>
                    </button>
                    <div dangerouslySetInnerHTML={this.state.viewHtml} />
                </div>
            )
        }
        if (this.state.videoAdded) {
            return (
                <div>
                    <button id="favbutton" type="button">
                        <span className="shredvidlistbutton-box"><img className="hornicon" src={'/images/horns.png'} />  Saved!</span>
                    </button>
                </div>
            )
        } 
        else return (
            <div>
                <button id="favbutton" type="button" onMouseDown={this.addFav}>
                    <span className="shredvidlistbutton-box"><img className="hornicon" src={'/images/horns.png'} />  Add To Favorites</span>
                </button>
            </div>
        )
    }
}
        
export default FavButton;