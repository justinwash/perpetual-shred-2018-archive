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
        axios.get("/Account/RemoveFav?vidUrl=" + this.props.shredVid.PlayerUrl)
            .then(res => {
                const removalStatus = res.data;
                this.setState({favRemoved: removalStatus});
            })
    }

    render() {
        if (this.state.favRemoved) {
            return (
                <div id="fav-remover">
                    REMOVED FROM FAVORITES
                </div>
            )
        }
        else {
            return (
                <div id="fav-remover">
                    <a onClick={this.removeFav}>REMOVE</a>
                </div>
            )
        }
    }
}

export default FavRemover;