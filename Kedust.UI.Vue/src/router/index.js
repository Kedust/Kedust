import Vue from "vue";
import VueRouter from "vue-router";
import Menu from "@/components/Menu";
import OrderLine from "@/components/OrderLine";

Vue.use(VueRouter);

const routes = [
    {
        name: 'Menu',
        path: '/',
        component: Menu,
        meta: {
            enterClass: "animate__animated animate__fadeIn animate__faster",
            leaveClass: "animate__animated animate__fadeOut animate__faster"
        }
    },
    {
        name: 'OrderItem',
        path: '/OrderItem/:id',
        component: OrderLine,
        meta: {
            enterClass: "animate__animated animate__fadeIn animate__faster",
            leaveClass: "animate__animated animate__fadeOut animate__faster"
        }
    }
];

const router = new VueRouter({
    mode:'history',
    base: process.env.BASE_URL,
    routes
})

export default router;