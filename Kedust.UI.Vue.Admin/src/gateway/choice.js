import axios from "axios";
import appConfig from "@/config";

export default {
    name: "Choice",
    getByMenu(id) {
        return axios.get(appConfig.api.domain + appConfig.api.choice.getByMenu,
            {
                params:{
                    id
                }
            })
            .then((response) => {
                return response.data;
            });
    }
}