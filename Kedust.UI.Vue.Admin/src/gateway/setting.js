import axios from "axios";
import appConfig from "@/config";

export default {
    name: "Setting",
    getCanPlaceOrder() {
        let url = appConfig.api.domain + appConfig.api.setting.getSetting;
        url = url.replace("{key}", "CanPlaceOrder")
        return axios.get( url)
            .then((response) => response.data);
    },
    setCanPlaceOrder(value) {
        let url = appConfig.api.domain + appConfig.api.setting.setSetting;
        url = url.replace("{key}", "CanPlaceOrder")
        url = url.replace("{value}", value?"True":"False");
        return axios
            .get(url)
            .then((response) => response.data);
    }
}