<template>
  <div class="page">
    <img src="/img/kedust-full-orange.svg" class="logo"/>
    <div class="row">
      <MenuItem v-for="item in menu" :key="item.id" :item="item"/>
    </div>
    <ShoppingCart v-if="false"></ShoppingCart>
  </div>
</template>

<style scoped>
.page{
  margin: 0rem 1rem 8rem 1rem;
  grid-row-start: 1;
  grid-column-start: 1;
}
.logo{
  display: block;
  margin: 1rem auto 1rem auto;
  max-width: 50vw;
  max-height: 12vh;
}
</style>

<script>

import {mapGetters} from "vuex"
import MenuItem from "@/components/MenuItem";
import ShoppingCart from "@/components/ShoppingCart";

export default {
  name: 'Menu',
  computed:{
    ...mapGetters({
      menu : "getMenu"
    })
  },
  components: {ShoppingCart, MenuItem},
  props: {
    items: [
      {
        id: Number,
        name: String,
        description: String,
        category: String,
        price: Number
      }
    ]
  }
}
</script>

