import React, { Component } from 'react';
import axios from 'axios';

class ShredComingUp extends Component {
    constructor(props) {
        super(props);
        this.state = {
            comingUp: { __html: "Error: Could not load upcoming awesomeness" },
            loading: false
        }

        this.getComingUpVids = this.getComingUpVids.bind(this);
    }

    componentDidMount() {
        this.getComingUpVids();
    }

    getComingUpVids() {
        this.setState({ loading: true });
        axios.get("/Query/ComingUp")
            .then(res => {
                const vidsubset = res.data.toString();
                this.setState({ comingUp: { __html: vidsubset } });
                this.setState({ loading: false });
            })
    }

    render() {
        if (this.state.loading) {
            return (
                <div id="loadingspinner" />
        )}
        else
            return (
                <div id="CUBox">
                    <div id="comingupheading">
                        COMING UP:
                    </div>
                    <div dangerouslySetInnerHTML={this.state.comingUp} />
                </div>
            )
    }
}

export default ShredComingUp;