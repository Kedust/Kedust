import axios from "axios";
import appConfig from "@/config";

export default {
    name: "Table",
    getAll() {
        return axios.get(appConfig.api.domain + appConfig.api.table.getAll)
            .then((response) => response.data);
    },
    get(id) {
        let url = appConfig.api.domain + appConfig.api.table.get;
        url = url.replace("{id}", id)
        return axios
            .get(url)
            .then((response) => response.data);
    },
    save(table) {
        return axios.put(appConfig.api.domain + appConfig.api.table.post, table)
            .then((response) => response.data);
    },
    delete(id) {
        let url = appConfig.api.domain + appConfig.api.table.delete;
        url = url.replace("{id}", id)
        return axios
            .delete(url)
            .then((response) => response.data);
    }
}