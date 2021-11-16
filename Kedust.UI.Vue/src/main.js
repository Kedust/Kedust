import 'materialize-css/dist/css/materialize.min.css';
import 'materialize-css/dist/js/materialize.min';
import Vue from 'vue'
import App from './App.vue';
import router from "@/router";
import store from "@/store";
import * as signalR from "@aspnet/signalr";


new Vue({
    router,
    store,
    render: h => h(App),
    async mounted() {
        this.$store.dispatch("fetchCanPlaceOrder").then(async () => {
            if (!this.$store.getters.getCanPlaceOrder) {
                if (this.$router.currentRoute.name !== "NotAvailable")
                    await this.$router.push({name: "NotAvailable"});
            }
        });
        let connection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:5001/PrintHub")
            .build();
        await connection.start();
        connection.on('updatedCanOrder', async () => {
            this.$store.dispatch("fetchCanPlaceOrder").then(async () => {
                if (!this.$store.getters.getCanPlaceOrder) {
                    if (this.$router.currentRoute.name !== "NotAvailable")
                        await this.$router.push({name: "NotAvailable"});
                }
                else{
                    console.log(this.$router.currentRoute.name)

                    if (this.$router.currentRoute.name === "NotAvailable")
                        await this.$router.push({name: "Menu"});

                }
            });
        });
    }
}).$mount('#app')