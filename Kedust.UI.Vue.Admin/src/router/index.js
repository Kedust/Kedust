import {createWebHashHistory, createRouter} from 'vue-router'
import Tables from '../views/Tables.vue'
import Menus from "@/views/Menus";
import Orders from "@/views/Orders";
import Settings from "@/views/Settings";
import Menu from "@/views/Menu";
import Dashboard from "@/views/Dashboard";
import Table from "@/views/Table";
import Login from "@/views/Login";

const routes = [
    {
        path: '/',
        name: 'Dashboard',
        component: Dashboard
    }, {
        path: '/Orders',
        name: 'Orders',
        component: Orders
    }, {
        path: '/Settings',
        name: 'Settings',
        component: Settings
    }, {
        path: '/Tables',
        name: 'Tables',
        component: Tables
    }, {
        path: '/Table/:id',
        name: 'TableEdit',
        component: Table
    }, {
        path: '/Table',
        name: 'TableNew',
        component: Table
    }, {
        path: '/Menus',
        name: 'Menus',
        component: Menus
    }, {
        path: '/Menu',
        name: 'MenuNew',
        component: Menu
    }, {
        path: '/Menu/:id',
        name: 'MenuEdit',
        component: Menu
    }, {
        path: '/Login',
        name: 'Login',
        component: Login
    }
]

const router = createRouter({
    history: createWebHashHistory(),
    routes
})
router.beforeEach((to, _, next) => {
    console.log(localStorage.getItem("userToken"))

    if (to.name !== "Login" && localStorage.getItem("loggedIn") === null) {
        console.log("NOT LOGED IN")
        next({name: "Login"})
    } else next();
})

export default router
