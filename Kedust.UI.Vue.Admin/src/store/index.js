import {createStore} from 'vuex'
import Gateway from "@/gateway/index"

export default createStore({
    state: {
        loading: false
    },
    mutations: {
        setLoading(state, payload) {
            state.loading = payload;
        }
    },
    actions: {
        setCanPlaceOrder: async (state, payload) => {
            await Gateway.Setting.setCanPlaceOrder(payload);
        }
    },
    getters: {
        getLoading: state => state.loading
    },
    modules: {}
})
