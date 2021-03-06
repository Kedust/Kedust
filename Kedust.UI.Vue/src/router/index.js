import Vue from "vue";
import VueRouter from "vue-router";
import Menu from "@/views/Menu";
import Choice from "@/views/Choice";
import ShoppingCart from "@/views/ShoppingCart";
import ThankYou from "@/views/ThankYou";
import SelectTable from "@/views/SelectTable";
import NotAvailable from "@/views/NotAvailable";
import QuickSelectTable from "@/views/QuickSelectTable";

Vue.use(VueRouter);

const routes = [
    {
        name: 'Menu',
        path: '/',
        component: Menu
    },
    {
        name: 'Choice',
        path: '/Choice',
        component: Choice
    },
    {
        name: 'ShoppingCart',
        path: '/ShoppingCart',
        component: ShoppingCart
    },
    {
        name: 'ThankYou',
        path: '/ThankYou',
        component: ThankYou
    },
    {
        name: 'Table',
        path: '/Table',
        component: SelectTable
    },
    {
        name: 'TableUrl',
        path: '/Table/:code',
        component: SelectTable
    },
    {
        name: 'NotAvailable',
        path: '/NotAvailable',
        component: NotAvailable
    },
    {
        name: 'QuickSelectTable',
        path: '/Ober',
        component: QuickSelectTable
    }
];

const router = new VueRouter({
    mode:'history',
    base: process.env.BASE_URL,
    routes
})

export default router;