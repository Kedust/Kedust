import axios from "axios";
import appConfig from "@/config";

export default {
    name: "Menu",
    getByTableCode(tableCode) {
        let url = appConfig.api.domain + appConfig.api.menu.getByTableCode;
        url = url.replace("{tableCode}", tableCode)
        return axios.get(url)
            .then((response) => response.data);
    }
}