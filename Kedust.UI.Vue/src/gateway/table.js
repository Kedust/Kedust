import axios from "axios";
import appConfig from "@/config";

export default {
    name: "Table",
    getByCode(tableCode) {
        let url = appConfig.api.domain + appConfig.api.table.getByCode;
        url = url.replace("{tableCode}", tableCode)
        return axios.get(url)
            .then((response) => {
                if(response.status === 204) return undefined;
                return response.data;
            });
    }
}