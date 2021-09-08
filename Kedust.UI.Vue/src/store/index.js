import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

const store = new Vuex.Store({
    state: {
        menu: [],
        currentMenuItem: {},
        loading: true
    },
    mutations: {
        setLoading(state, payload) {
            this.state.loading = payload;
        },
        setMenu(state, payload) {
            console.log("setMenu: start")
            payload.forEach(x => x.count = 0);
            this.state.menu = payload;

            console.log("setMenu: end")
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
        async fetchMenu(state) {

            console.log("fetchMenu: start");

            state.commit('setLoading', true);
            const response = await fetch("https://192.168.0.160:4000/Menu");
            state.commit('setMenu', await response.json());
            state.commit('setLoading', false);


            console.log("fetchMenu: end")

        },
        async Send(context) {
            const response = await fetch("https://192.168.0.160:4000/Order", {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(context.getters.getOrderItems)
            });

            return response.status === 200;

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
        getOrderItems: state => state.menu.filter(i => i.count > 0)
    }
});

export default store;