import Vue from "vue";
import VueRouter from "vue-router";
import Menu from "@/views/Menu";
import OrderLine from "@/views/MenuItemDetails";
import ShoppingCart from "@/views/OrderOverview";
import OrderConfirmation from "@/views/OrderConfirmation";

Vue.use(VueRouter);

const routes = [
    {
        name: 'Menu',
        path: '/',
        component: Menu
    },
    {
        name: 'OrderItem',
        path: '/OrderItem',
        component: OrderLine
    },
    {
        name: 'OrderOverview',
        path: '/OrderOverview',
        component: ShoppingCart
    },
    {
        name: 'OrderConfirmation',
        path: '/OrderConfirmation',
        component: OrderConfirmation
    }
];

const router = new VueRouter({
    mode:'history',
    base: process.env.BASE_URL,
    routes
})

export default router;