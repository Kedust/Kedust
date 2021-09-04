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
        setLoading(state, payload){
            this.state.loading = payload;
        },
        setMenu(state, payload) {
            payload.forEach(x => x.count = 0);
            this.state.menu = payload;
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
            if (item != undefined) {
                if (item.count === undefined) item.count = 0;
                item.count++;
            }
        },
        decrementCurrentOrderItem() {
            let item = this.state.currentMenuItem;
            if (item != undefined) {
                item.count--;
                if (item.count < 0) item.count = 0;
            }
        },
    },
    actions: {
        async fetchMenu(state) {
            state.commit('setLoading', true);
            await setTimeout(() => {
                let menu = [
                    {
                        id: 1,
                        name: "Plat water",
                        category: "Drank",
                        price: 1.8
                    },
                    {
                        id: 2,
                        name: "Spuitwater",
                        category: "Drank",
                        price: 1.8
                    },
                    {
                        id: 3,
                        name: "Cola",
                        category: "Drank",
                        price: 1.8
                    },
                    {
                        id: 4,
                        name: "Fanta",
                        category: "Drank",
                        price: 1.8
                    },
                    {
                        id: 8,
                        name: "Jupiler",
                        description: "blonde pils, 5.2%",
                        category: "Drank",
                        price: 1.8
                    },
                    {
                        id: 5,
                        name: "Witte wijn",
                        description: "Fratelli A&R 'Rive dei Sassi' Roero Arneis",
                        category: "Drank",
                        price: 3
                    },
                    {
                        id: 6,
                        name: "Rozé wijn",
                        description: "La Pauline 'Plaisir' Rosé",
                        category: "Drank",
                        price: 3
                    },
                    {
                        id: 7,
                        name: "Rode wijn",
                        description: "Blackhawk Merlot",
                        category: "Drank",
                        price: 3
                    },
                    {
                        id: 9,
                        name: "Duvel",
                        description: "blond, 8.5%",
                        category: "Drank",
                        price: 2.4
                    },
                    {
                        id: 10,
                        name: "Omer",
                        description: "blond, 8.0%",
                        category: "Drank",
                        price: 2.4
                    },
                    {
                        id: 11,
                        name: "Gouden Carolus",
                        description: "Tripel, 9.0%",
                        category: "Drank",
                        price: 2.4
                    },
                    {
                        id: 12,
                        name: "Cornet",
                        description: "Blond, 8.5%",
                        category: "Drank",
                        price: 2.4
                    },
                    {
                        id: 13,
                        name: "Wittekerke",
                        description: "Witbier, 5.8%",
                        category: "Drank",
                        price: 2.4
                    }
                ];
                state.commit('setMenu', menu);
                state.commit('setLoading', false);

            }, 1000);

        },
        async Send(context) {
            return new Promise((resolve) => {
                console.log(JSON.stringify(context.getters.getOrderItems));
                context.dispatch('fetchMenu')
                resolve()

            });

        }
    },
    getters: {
        getLoading: state => state.loading,
        getMenu: state => state.menu,
        getCurrentMenuItem: state => state.currentMenuItem,
        getOrderCount: (state) => {
            const reducer = (accumulator, currentValue) => accumulator + currentValue;
            return state.menu.map(i => i.count).reduce(reducer);
        },
        getOrderPrice: (state) => {
            const reducer = (accumulator, currentValue) => accumulator + currentValue;
            return state.menu.map(i => i.count * i.price).reduce(reducer).toFixed(2);
        },
        getLastUpdate: state => state.lastUpdate,
        getOrderItems: state => state.menu.filter(i => i.count > 0)
    }
});

export default store;