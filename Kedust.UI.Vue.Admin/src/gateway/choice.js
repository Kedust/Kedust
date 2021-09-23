import axios from "axios";
import appConfig from "@/config";

export default {
    name: "Choice",
    getByMenu(id) {
        return axios.get(appConfig.api.domain + appConfig.api.choice.getByMenu,
            {
                params: {
                    id
                }
            })
            .then((response) => {
                console.log(response.data)
                return response.data;
            });
    },
    saveByMenu(menuId, choices) {
        let data = {
            menu: menuId,
            choices: choices
        };
        return axios.post(appConfig.api.domain + appConfig.api.choice.saveByMenu, data)
            .then((response) => response.data);
    },
}