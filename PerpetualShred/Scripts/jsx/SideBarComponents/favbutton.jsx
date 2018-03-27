import React, { Component } from 'react';
import axios from "axios/index";

class FavButton extends Component {
    constructor(props) {
        super(props);
        this.state = {
            videoAdded: null
        };
        this.addFav = this.addFav.bind(this);
    }
    
    
    addFav(){
        axios.get("/Account/AddFav?vidUrl=" + jsModel.PlayerUrl)
            .then(res => {
                const addResult = res.data;
                this.setState({videoAdded: addResult});
            })   
    }
    
    render() {
        return (
            <div>
                <button id="favbutton" type="button" onMouseDown={this.addFav}>
                    <span className="shredvidlistbutton-box"><img className="hornicon" src={'/images/horns.png'} />  Add To Favorites</span>
                </button>
            </div>
        )
    }
}
        
export default FavButton;