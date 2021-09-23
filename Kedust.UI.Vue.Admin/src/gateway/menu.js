import axios from "axios";
import appConfig from "@/config";

export default {
    name: "Menu",
    getAll() {
        return axios.get(appConfig.api.domain + appConfig.api.menu.getAll)
            .then((response) => response.data);
    },
    get(id) {
        return axios
            .get(appConfig.api.domain + appConfig.api.menu.get, {
                params: {id}
            })
            .then((response) => response.data);
    }
}