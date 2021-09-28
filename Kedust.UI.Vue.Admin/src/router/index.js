import {createWebHashHistory, createRouter} from 'vue-router'
import Tables from '../views/Tables.vue'
import Menus from "@/views/Menus";
import Orders from "@/views/Orders";
import Menu from "@/views/Menu";
import Dashboard from "@/views/Dashboard";
import Table from "@/views/Table";

const routes = [


  {
    path: '/',
    name: 'Dashboard',
    component: Dashboard
  },{
    path: '/Orders',
    name: 'Orders',
    component: Orders
  },{
    path: '/Tables',
    name: 'Tables',
    component: Tables
  },{
    path: '/Table/:id',
    name: 'TableEdit',
    component: Table
  },{
    path: '/Table',
    name: 'TableNew',
    component: Table
  },{
    path: '/Menus',
    name: 'Menus',
    component: Menus
  },{
    path: '/Menu',
    name: 'MenuNew',
    component: Menu
  },{
    path: '/Menu/:id',
    name: 'MenuEdit',
    component: Menu
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
