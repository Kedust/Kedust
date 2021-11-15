import axios from "axios";
import appConfig from "@/config";

export default {
    name: "Menu",
    getById(id) {
        let url = appConfig.api.domain + appConfig.api.menu.getById;
        url = url.replace("{id}", id)
        return axios.get(url)
            .then((response) => {
                if(response.status === 204) return undefined;
                return response.data;
            });
    }
}