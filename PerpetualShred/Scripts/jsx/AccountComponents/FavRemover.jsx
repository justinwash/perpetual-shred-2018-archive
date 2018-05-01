import React, {Component} from 'react';
import axios from 'axios';
import ReactDOM from "react-dom";

class FavRemover extends Component {
    constructor(props) {
        super(props);
        this.state = {
            favRemoved: false,
        };
        this.removeFav = this.removeFav.bind(this);
    }

    removeFav() {
        var vidUrl = this.props.shredVid.playerUrl;
        axios.get("/Account/RemoveFav?vidUrl=" + vidurl)
            .then(res => {
                const removalStatus = res.data;
                this.setState({favRemoved: removalStatus});
            })
    }

    render() {
        if (this.state.favRemoved) {
            return (
                <div id="remove-fav">
                    REMOVED FROM FAVORITES
                </div>
            )
        }
        else {
            return (
                <div id="remove-fav">
                    <a onClick={this.removeFav}>REMOVE</a>
                </div>
            )
        }
    }
}

export default FavRemover;