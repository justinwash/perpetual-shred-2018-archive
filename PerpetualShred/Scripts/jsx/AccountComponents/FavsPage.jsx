import React, { Component } from 'react';
import FavPageTitle from './FavPageTitle.jsx';
import FavContainer from './FavContainer.jsx';
import axios from 'axios';

class FavsPage extends Component {
    constructor(props){
        super(props);
        this.state = {
            error: false,
            loading: false,
            favorites: null
        };
        this.CreateFavsList = this.CreateFavsList.bind(this);
        this.getUserFavs = this.getUserFavs.bind(this);
    }
    
    componentDidMount(){
        this.getUserFavs();
    }
    
    CreateFavsList() {
        var favs = this.state.favorites;
        if (favs == null) return (<div>something went wrong</div>);
        
        var displayFavs = favs.map((fav) =>
            <FavContainer shredVid={fav} />
        );
        
        return (
            <div>
                {displayFavs}
            </div>
        );
    }

    getUserFavs() {
        this.setState({loading: true});
        var favObjectList = null;
        axios.get("/Account/GetFavObjects")
            .then(res => {
                favObjectList = res.data;
                this.setState({ favorites: favObjectList});
                this.setState({loading: false});
            })
    }
    
    render() {
        return (
            <div>
                <FavPageTitle title="My Shredness" />
                <this.CreateFavsList />
            </div>
        )
    }
    
}

export default FavsPage;