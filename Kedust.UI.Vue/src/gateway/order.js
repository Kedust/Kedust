import axios from "axios";
import appConfig from "@/config";

export default {
    name: "Order",
    post(data) {
        return axios.post(appConfig.api.domain + appConfig.api.order.post, data)
            .then((response) => response.data);
    }
}