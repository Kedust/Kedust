import axios from "axios";
import appConfig from "@/config";

export default {
    name: "Choice",
    getByTableCode(code) {
        return axios.get(appConfig.api.domain + appConfig.api.choice.getByTableCode,
            {
                params:{
                    code
                }
            })
            .then((response) => {
                return response.data;
            });
    }
}