import { createRouter, createWebHistory } from 'vue-router';
import Menu from "@/components/Menu";
import MenuItemDetails from "@/components/MenuItemDetails";
import 'animate.css';

const router = createRouter({
    history: createWebHistory(),
    routes:[
        {
            path:'/',
            component:Menu,
            meta:{
                enterClass:"animate__animated animate__fadeInLeftBig",
                leaveClass:"animate__animated animate__fadeOutRightBig"
            }
        },
        {
            path:'/Item/:id',
            component:MenuItemDetails,
            meta:{
                enterClass:"animate__animated animate__fadeInRightBig",
                leaveClass:"animate__animated animate__fadeOutLeftBig"
            }
        }
    ]
});

export default router;