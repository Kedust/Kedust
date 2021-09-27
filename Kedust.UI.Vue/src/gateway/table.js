import axios from "axios";
import appConfig from "@/config";

export default {
    name: "Table",
    checkCode(tableCode) {
        let url = appConfig.api.domain + appConfig.api.table.checkCode;
        url = url.replace("{tableCode}", tableCode)
        return axios.get(url)
            .then((response) => response.data);
    }
}