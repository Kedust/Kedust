import {createStore} from 'vuex'

export default createStore({
    state: {
        loading: false
    },
    mutations: {
        setLoading(state, payload) {
            state.loading = payload;
        }
    },
    actions: {},
    getters: {
        getLoading: state => state.loading
    },
    modules: {}
})
