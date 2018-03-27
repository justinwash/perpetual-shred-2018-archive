import React, { Component } from 'react';

class FavButton extends Component {
    constructor(props) {
        super(props);
        this.state = {};
        this.addFav = this.addFav.bind(this);
    }
    
    addFav(){
        // Add video to favorites. Axios, etc    
    }
    
    render() {
        return (
            <div id="favbuttonbox"><a href="" onClick={this.addFav}>
                <img className="hornicon" src={'/images/horns.png'} />  Add To Favorites</a>
            </div>
        )
    }
}
        
export default FavButton;