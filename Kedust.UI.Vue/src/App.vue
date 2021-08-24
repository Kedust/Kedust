

<template>
  <div>
    <img src=""></img>
    <router-link to="/">Home</router-link>
    <router-link to="/Item">Item</router-link>
  <router-view v-slot="{ Component, route }">
    <transition :enter-active-class="route.meta.enterClass"
                :leave-active-class="route.meta.leaveClass"
                >
      <component :is="Component"/>
    </transition>
  </router-view>
  </div>
</template>

<style>

a{
  font-weight:bold;
  color: #2c3e50;
  text-decoration: none;
  margin-right: 1em;
}

.page{
  position: absolute;
  top:30px;
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