import { createStore } from 'vuex'
import {fetchWithParam} from "@/helpers/FetchWithParam";
import appConfig from "@/config";

export default createStore({
  state: {
    menus: []
  },
  mutations: {
    menus__update_all(state, payload){
      console.log(payload);
      state.menus = payload;
    }
  },
  actions: {
    async menus__update_all(state){
      const response = await fetchWithParam(appConfig.apiDomain + appConfig.apiPath_Menus_GetAll);
      state.commit("menus__update_all", await response.json());
    }
  },
  getters: {
    getMenus: state => state.menus
  },
  modules: {
  }
})
