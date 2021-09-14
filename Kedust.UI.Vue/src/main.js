import 'materialize-css/dist/css/materialize.min.css';
import 'materialize-css/dist/js/materialize.min';
import Vue from 'vue'
import App from './App.vue';
import router from "@/router";
import store from "@/store";


new Vue({
    router,
    store,
    render: h => h(App)
}).$mount('#app')