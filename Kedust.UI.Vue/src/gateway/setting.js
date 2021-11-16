import axios from "axios";
import appConfig from "@/config";

export default {
    name: "Setting",
    getByKey(key) {
        let url = appConfig.api.domain + appConfig.api.settings.getByKey;
        url = url.replace("{key}", key)
        return axios.get(url)
            .then((response) => {
                if(response.status === 204) return undefined;
                return response.data;
            });
    }
}