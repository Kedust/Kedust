import Vue from "vue";
import Vuex from "vuex";
import {fetchWithParam} from "@/Helpers/FetchWithParam";

Vue.use(Vuex);
const baseUrl = "https://api.kedust.be";

const store = new Vuex.Store({
    state: {
        menu: [],
        currentMenuItem: {},
        table: undefined,
        loading: false
    },
    mutations: {
        setTable(state, payload){
            state.table = payload;
        },
        setLoading(state, payload) {
            state.loading = payload;
        },
        setMenu(state, payload) {
            payload.forEach(x => x.count = 0);
            state.menu = payload;
        },
        setCurrentMenuItem(state, payload) {
            this.state.currentMenuItem = payload;
        },
        incrementOrderItem(state, id) {
            let item = this.state.menu.find(x => x.id === id);
            item.count++;
        },
        decrementOrderItem(state, id) {
            let item = this.state.menu.find(x => x.id === id);
            item.count--;
            if (item.count < 0) item.count = 0;
        },
        incrementCurrentOrderItem() {
            let item = this.state.currentMenuItem;
            if (item !== undefined) {
                if (item.count === undefined) item.count = 0;
                item.count++;
            }
        },
        decrementCurrentOrderItem() {
            let item = this.state.currentMenuItem;
            if (item !== undefined) {
                item.count--;
                if (item.count < 0) item.count = 0;
            }
        },
    },
    actions: {

        async checkTable(context, payload){

            const result = (await fetchWithParam(baseUrl + "/Table/CheckCode", {
                    method: 'GET',
                    queryParams: {code: payload}
                }
            ));
            const jsonResult = await result.json()
            return jsonResult.success;
        },
        async updateMenu(state) {
            state.commit('setLoading', true);
            const response = await fetch(baseUrl + "/Menu");
            state.commit('setMenu', await response.json());
            state.commit('setLoading', false);
        },
        async sendOrder(context) {
            const response = await fetch(baseUrl + "/Order", {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(context.getters.getOrderItems)
            });
            return response.ok;
        }
    },
    getters: {
        getLoading: state => state.loading,
        getMenu: state => state.menu,
        getCurrentMenuItem: state => state.currentMenuItem,
        getOrderCount: (state) => {
            if (state.menu.length === 0) return 0;
            const reducer = (accumulator, currentValue) => accumulator + currentValue;
            return state.menu.map(i => i.count).reduce(reducer);
        },
        getOrderPrice: (state) => {
            if (state.menu.length === 0) return 0;
            const reducer = (accumulator, currentValue) => accumulator + currentValue;
            return state.menu.map(i => i.count * i.price).reduce(reducer).toFixed(2);
        },
        getOrderItems: state => state.menu.filter(i => i.count > 0),
        getTable: state => state.table,
        getTableAvailable: state => state.table !== undefined
}
});

export default store;