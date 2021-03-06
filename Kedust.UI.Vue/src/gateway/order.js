import axios from "axios";
import appConfig from "@/config";

export default {
    name: "Order",
    post(data) {
        return axios.put(appConfig.api.domain + appConfig.api.order.post, data)
            .then((response) => {
                if(response.status === 204) return undefined;
                return response.data;
            });
    }
}