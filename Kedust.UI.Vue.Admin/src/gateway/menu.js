import axios from "axios";
import appConfig from "@/config";

export default {
    name: "Menu",
    getAll() {
        return axios.get(appConfig.api.domain + appConfig.api.menu.getAll)
            .then((response) => response.data);
    },
    get(id) {
        let url = appConfig.api.domain + appConfig.api.menu.get;
        url = url.replace("{id}", id)
        return axios
            .get(url)
            .then((response) => response.data);
    },
    save(menu) {
        return axios.put(appConfig.api.domain + appConfig.api.menu.post, menu)
            .then((response) => response.data);
    },
    delete(id) {
        let url = appConfig.api.domain + appConfig.api.menu.delete;
        url = url.replace("{id}", id)
        return axios
            .delete(url)
            .then((response) => response.data);
    }
}