

<template>
  <div>
    <router-link to="/">MENU</router-link>
    <router-link to="/Item">ITEM</router-link>
    <img src="/img/kedust-full.svg" class="logo"/>
    <div class="page-container">
  <router-view v-slot="{ Component, route }">
  <transition :enter-active-class="route.meta.enterClass"
                :leave-active-class="route.meta.leaveClass">
      <component :is="Component"/>
    </transition>
  </router-view>
    </div>

  </div>
</template>

<style>

a{
  font-weight:bold;
  color: #2c3e50;
  text-decoration: none;
  margin-right: 1em;
}

.logo{
  display: block;
  margin-left: auto;
  margin-right: auto;
  width: 60vw;
  max-height: 20vh;
}
.page-container{
  display: grid;
  grid-template-columns: 1fr;
}
.page{
  grid-row-start: 1;
  grid-column-start: 1;
}

  a:hover,
  a.router-link-active{
    border-bottom:2px solid #3498db;
  }

  .fade-enter-from,
  .fade-leave-to{
    opacity: 0;
  }
  .fade-enter-active,
  .fade-leave-active{
    transition: opacity 0.5s ease-out;
  }
</style>
<script>
import Menu from "@/components/Menu";
import MenuItemDetails from "@/components/MenuItemDetails";
export default {
  components: {MenuItemDetails, Menu}
}
</script>