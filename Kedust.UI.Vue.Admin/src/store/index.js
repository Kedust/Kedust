import { createStore } from 'vuex'

export default createStore({
  state: {
  },
  mutations: {
  },
  actions: {
    async gotoRoute(payload){
      await this.$router.push({name: payload});
    }
  },
  modules: {
  }
})
