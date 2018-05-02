import React, {Component} from 'react';
import axios from 'axios';
import ReactDOM from "react-dom";

class FavRemover extends Component {
    constructor(props) {
        super(props);
        this.state = {
            favRemoved: false,
            error: false
        };
        this.removeFav = this.removeFav.bind(this);
        this.undoRemove = this.undoRemove.bind(this);
    }

    removeFav() {
        var vidUrl = this.props.shredVid.playerUrl;
        axios.get("/Account/RemoveFav?vidUrl=" + vidUrl)
            .then(res => {
                const removalStatus = res.data;
                this.setState({favRemoved: removalStatus});
            })
    }
    
    undoRemove(){
        axios.get("/Account/AddFav?vidUrl=" + this.props.shredVid.playerUrl)
            .then(res => {
                const addResult = res.data;
                this.setState({ favRemoved: !addResult });
                if (!addResult){
                    this.setState( { error: true });
                }
            })
    }

    render() {
        if (this.state.favRemoved) {
            return (
                <div id="remove-fav">
                    <button onClick={this.undoRemove}>REMOVED. UNDO?</button>
                </div>
            )
        }
        else {
            return (
                <div id="remove-fav">
                    <button onClick={this.removeFav}>REMOVE</button>
                </div>
            )
        }
    }
}

export default FavRemover;