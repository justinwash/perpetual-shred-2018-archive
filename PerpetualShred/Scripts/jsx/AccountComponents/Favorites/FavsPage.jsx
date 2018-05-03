import React, { Component } from 'react';
import FavPageTitle from './FavPageTitle.jsx';
import FavContainer from './FavContainer.jsx';
import axios from 'axios';
import AccountHelper from "../../../accounthelper";

class FavsPage extends Component {
    constructor(props){
        super(props);
        this.state = {
            error: false,
            loading: false,
            favorites: null
        };
        this.CreateFavsList = this.CreateFavsList.bind(this);
    }
    
    async componentDidMount(){
        var favs = await AccountHelper.getFavObjects();
        this.setState({ favorites: favs });
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
    
    render() {
            return (
                <div>
                    <FavPageTitle title="My Shredness"/>
                    <this.CreateFavsList/>
                </div>
            )
        }
    
}

export default FavsPage;