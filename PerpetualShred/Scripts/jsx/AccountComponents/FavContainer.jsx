import React, { Component } from 'react';
import FavRemover from './FavRemover.jsx';

class FavContainer extends Component {
    constructor(props){
        super(props);
        this.state = {
            error: false,
            loading: false
        }
    }

    render() {
        return (
            <div className="vidPageContainer">
                <div className="vidInfoContainer">
                    <div className="vidThumbContainer">
                        <a href={this.props.shredVid.originUrl}>
                            <img src={this.props.shredVid.thumbnail} />
                        </a>
                    </div>
                    <div className="vidTextContainer">
                        <div className="vidTitle">
                            <a href={"/Home/Index/" + this.props.shredVid.id}>
                                {this.props.shredVid.title}
                            </a>
                        </div>
                        <div id="date-and-control">
                            <div className="vidReleaseDate">{this.props.shredVid.releaseDate}</div>
                            <FavRemover shredVid={this.props.shredVid} />
                        </div>
                    </div>
                </div>
            </div>
        )
    }

}

export default FavContainer;