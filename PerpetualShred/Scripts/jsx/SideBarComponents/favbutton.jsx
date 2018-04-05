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
            logViewHtml: null,
            regViewHtml: null
        };
        this.addFav = this.addFav.bind(this);
        this.getLoginStatus = this.getLoginStatus.bind(this);
        this.getLoginView = this.getLoginView.bind(this);
        this.getRegisterView = this.getRegisterView.bind(this);
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
                this.setState({ logViewHtml: {__html: loginHtml },
                                regViewHtml: {__html: null },
                                loading: false,
                                });
            })
    }

    getRegisterView() {
        this.setState({ loading: true });
        axios.get("/Account/Register")
            .then(res => {
                const regHtml = res.data.toString();
                this.setState({ regViewHtml: {__html: regHtml }, 
                                logViewHtml: {__html: null},
                                loading: false });
            })
    }
    
    render() {
        if (this.state.error) {
            return (
                <div>
                    <button id="favbutton" type="button">
                        <span className="favbutton-box"><img className="hornicon" src={'/images/horns.png'} /> Error :(</span>
                    </button>
                </div>
            )
        }
        if (this.state.loading) {
            return (
                <div>
                    <button id="favbutton" type="button">
                        <span className="favbutton-box"><img className="hornicon" src={'/images/horns.png'} />  Please wait...</span>
                    </button>
                </div>
            )
        }
        if (!this.state.isLoggedIn) {
            return (
                <div>
                    <button id="favbutton" type="button" onMouseDown={this.getLoginView}>
                        <span className="loginbutton"><img className="hornicon" src={'/images/horns.png'} /> Login</span>
                    </button>
                    <br/>
                    <button id="favbutton" type="button" onMouseDown={this.getRegisterView}>
                        <span className="registerbutton"><img className="hornicon" src={'/images/horns.png'} />  Register</span>
                    </button>
                    <div dangerouslySetInnerHTML={this.state.logViewHtml} />
                    <div dangerouslySetInnerHTML={this.state.regViewHtml} /> 
                </div>
            )
        }
        if (this.state.videoAdded) {
            return (
                <div>
                    <button id="favbutton" type="button">
                        <span className="favbutton-box"><img className="hornicon" src={'/images/horns.png'} />  Saved!</span>
                    </button>
                </div>
            )
        } 
        else return (
            <div>
                <button id="favbutton" type="button" onMouseDown={this.addFav}>
                    <span className="favbutton-box"><img className="hornicon" src={'/images/horns.png'} />  Add To Favorites</span>
                </button>
            </div>
        )
    }
}
        
export default FavButton;