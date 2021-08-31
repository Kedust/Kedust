<template>
  <div>
    <div class="page-container">
      <router-view v-slot="{ Component, route }">
        <transition mode="out-in"
                    :enter-active-class="route.meta.enterClass"
                    :leave-active-class="route.meta.leaveClass">
          <component :is="Component"/>
        </transition>
      </router-view>
    </div>

  </div>
</template>

<style>

body{
  font-family: 'Roboto', sans-serif;}


.page-container{
  display: grid;
  grid-template-columns: 1fr;
}


</style>
<script>
import Menu from "@/components/Menu";
import MenuItemDetails from "@/components/OrderLine";
export default {
  components: {MenuItemDetails, Menu}
}
</script>