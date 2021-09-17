import {createWebHashHistory, createRouter} from 'vue-router'
import Tables from '../views/Tables.vue'
import Menus from "@/views/Menus";
import Orders from "@/views/Orders";

const routes = [
  {
    path: '/Orders',
    alias:['/'],
    name: 'Orders',
    component: Orders
  },
  {
    path: '/Tables',
    name: 'Tables',
    component: Tables
  },{
    path: '/Menus',
    name: 'Menus',
    component: Menus
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
