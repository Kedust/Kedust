import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

const store = new Vuex.Store({
    state: {
        order: [],
        menu: [
            {
                id: 1,
                name: "Plat water",
                description: "",
                category: "Drank",
                price: 1.8
            },
            {
                id: 2,
                name: "Spuitwater",
                description: "",
                category: "Drank",
                price: 1.8
            },
            {
                id: 3,
                name: "Cola",
                description: "",
                category: "Drank",
                price: 1.8
            },
            {
                id: 4,
                name: "Fanta",
                description: "",
                category: "Drank",
                price: 1.8
            },
            {
                id: 5,
                name: "Witte wijn",
                description: "Spa",
                category: "Drank",
                price: 1.8
            },
            {
                id: 6,
                name: "Roze wijn",
                description: "Spa",
                category: "Drank",
                price: 1.8
            },
            {
                id: 7,
                name: "Witte wijn",
                description: "Spa",
                category: "Drank",
                price: 1.8
            },
            {
                id: 8,
                name: "Rode wijn",
                description: "Spa",
                category: "Drank",
                price: 1.8
            },
            {
                id: 9,
                name: "Duvel",
                description: "Spa",
                category: "Drank",
                price: 1.8
            },
            {
                id: 10,
                name: "Omer",
                description: "Spa",
                category: "Drank",
                price: 1.8
            },
            {
                id: 11,
                name: "Gouden Carolus",
                description: "Spa",
                category: "Drank",
                price: 1.8
            },
            {
                id: 12,
                name: "Cornet",
                description: "Spa",
                category: "Drank",
                price: 1.8
            },
            {
                id: 13,
                name: "Wittekerke",
                description: "Spa",
                category: "Drank",
                price: 1.8
            }
        ]
    },
    mutations: {},
    actions: {},
    modules: {},
    getters: {
        getMenu: state => state.menu,
        getOrder: state => state.order
    }
});

export default store;