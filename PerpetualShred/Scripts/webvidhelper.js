import axios from 'axios';

class WebVidHelper {

    async getVidSubset(start, count) {
        var data = null;
        await axios.get("/Query/Fetch?subindex=" + start + "!" + count)
            .then(res => {
                 data = res.data;
            });
        return data;
    }
    
    
    
}

export default WebVidHelper;