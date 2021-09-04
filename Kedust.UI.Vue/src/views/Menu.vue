<template>
  <div class="page">
    <div class="row">
      <MenuItem v-for="item in menu" :key="item.id" :item="item"/>
    </div>
    <ShoppingCartButton v-if="itemCount>0"></ShoppingCartButton>
  </div>
</template>

<style scoped>
.page{
  margin: 1rem 1rem 5.25rem 1rem;
}
</style>

<script>

import {mapGetters} from "vuex"
import MenuItem from "@/components/MenuItem";
import ShoppingCartButton from "@/components/ShoppingCartButton";


export default {
  name: 'Menu',
  computed:{
    ...mapGetters({
      menu : "getMenu",
      itemCount: "getOrderCount"
    })
  },
  components: {ShoppingCartButton, MenuItem}
}
</script>

