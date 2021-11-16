import Vue from "vue";
import Vuex from "vuex";
import Gateway from "@/gateway/index"

Vue.use(Vuex);

const store = new Vuex.Store({
    state: {
        menu: undefined,
        currentMenuItem: {},
        table: undefined,
        loading: false,
        isWaiter: false,
        canPlaceOrder: true
    },
    actions: {
        async fetchCanPlaceOrder() {
            let response = await Gateway.Setting.getByKey("CanPlaceOrder");
            await this.commit("setCanPlaceOrder", response === "True");
        }
    },
    mutations: {
        setCanPlaceOrder(state, payload){
            state.canPlaceOrder = payload;
        },
        setTable(state, payload) {
            state.table = payload;
        },
        setIsWaiter(state, payload) {
            state.isWaiter = payload;
        },
        setLoading(state, payload) {
            state.loading = payload;
        },
        setMenu(state, payload) {
            payload.choices.forEach(x => x.count = 0);
            payload.choices = payload.choices.sort((a, b) => (a.sorting > b.sorting) ? 1 : -1)
            state.menu = payload;
        },
        setCurrentMenuItem(state, payload) {
            this.state.currentMenuItem = payload;
        },
        incrementOrderItem(state, id) {
            let item = this.state.menu.choices.find(x => x.id === id);
            item.count++;
        },
        decrementOrderItem(state, id) {
            let item = this.state.menu.choices.find(x => x.id === id);
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
        }
    },
    getters: {
        getLoading: state => state.loading,
        getMenu: state => state.menu,
        getIsWaiter: state => state.isWaiter,
        getCurrentMenuItem: state => state.currentMenuItem,
        getOrderCount: (state) => {
            if (state.menu === undefined || state.menu.choices === undefined || state.menu.choices.length === 0) return 0;
            const reducer = (accumulator, currentValue) => accumulator + currentValue;
            return state.menu.choices.map(i => i.count).reduce(reducer);
        },
        getOrderPrice: (state) => {
            if (state.menu === undefined || state.menu.choices === undefined || state.menu.choices.length === 0) return 0;
            const reducer = (accumulator, currentValue) => accumulator + currentValue;
            return state.menu.choices.map(i => i.count * i.price).reduce(reducer);
        },
        getOrderItems: state => {
            if (state.menu === undefined || state.menu.choices === undefined) return undefined;
            return state.menu.choices.filter(i => i.count > 0)
        },
        getTable: state => state.table,
        getTableAvailable: state => state.table !== undefined,
        getCanPlaceOrder: state => state.canPlaceOrder
    }
});

export default store;