import axios from 'axios';

class AccountHelper {

    static async getLoginStatus() {
        var status = null;
        await axios.get("/Account/IsLoggedIn")
            .then(res => {
                status = res.data;
            });
        return status;
    }

    static async getFavObjects() {
        var data = null;
        await axios.get("/Account/GetFavObjects")
            .then(res => {
                data = res.data;
            });
        return data;
    }

    static async removeFav(vidUrl) {
        var data = null;
        await axios.get("/Account/RemoveFav?vidUrl=" + vidUrl)
            .then(res => {
                data = res.data;
            });
        return data;
    }

    static async addFav(vidUrl) {
        var data = null;
        await axios.get("/Account/AddFav?vidUrl=" + vidUrl)
            .then(res => {
                data = res.data;
            });
        return data;
    }

    static async getLoginView() {
        var loginPage = null;
        await axios.get("/Account/Login")
            .then(res => {
                loginPage = res.data.toString();
            });
        return loginPage;
    }

    static async getRegView() {
        var regPage = null;
        await axios.get("/Account/Register")
            .then(res => {
                regPage = res.data.toString();
            });
        return regPage;
    }

    static async logout() {
        var result = null;
        await axios.get("/Account/Logout")
            .then(res => {
                result = res.data;
            });
        return false;
    }
}

export default AccountHelper;