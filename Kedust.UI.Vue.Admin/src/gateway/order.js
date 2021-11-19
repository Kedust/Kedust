import axios from "axios";
import appConfig from "@/config";

export default {
    name: "Order",
    getAll(from, till) {
        return axios.get(appConfig.api.domain + appConfig.api.order.getAll, {params: {from, till}})
            .then((response) => response.data);
    }
}