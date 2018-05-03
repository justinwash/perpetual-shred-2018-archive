import React, {Component} from 'react';
import AccountHelper from "../../../accounthelper";

class FavRemover extends Component {
    constructor(props) {
        super(props);
        this.state = {
            favRemoved: false,
            error: false
        };
        this.removeClicked = this.removeClicked.bind(this);
        this.undoClicked = this.undoClicked.bind(this);
    }

    async removeClicked() {
        var removed = await AccountHelper.removeFav(this.props.shredVid.playerUrl);
        this.setState({ favRemoved: removed });
    }
    
    async undoClicked(){
        var undone = await AccountHelper.addFav(this.props.shredVid.playerUrl);
        this.setState({ favRemoved: !undone })
    }

    render() {
        if (this.state.favRemoved) {
            return (
                <div id="remove-fav">
                    <button onClick={this.undoClicked}>REMOVED. UNDO?</button>
                </div>
            )
        }
        else {
            return (
                <div id="remove-fav">
                    <button onClick={this.removeClicked}>REMOVE</button>
                </div>
            )
        }
    }
}

export default FavRemover;