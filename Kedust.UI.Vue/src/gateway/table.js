import axios from "axios";
import appConfig from "@/config";

export default {
    name: "Table",
    checkCode(code) {
        return axios.get(appConfig.api.domain + appConfig.api.table.checkCode,{
            params:{code}
        })
            .then((response) => response.data);
    }
}