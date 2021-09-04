<template>
  <div class="page">
    <div v-if="itemCount == 0">Er zit nog niets in je winkelmandje.</div>
    <div class="row">
      <ShoppingCartItem v-for="item in menu" :key="item.id" :item="item"/>
    </div>
    <router-link class="button primary" :to="{name: 'Menu'}">Menu</router-link>
    <div v-if="itemCount>0" class="button primary-bg" @click="Send">Verzenden</div>
  </div>
</template>

<style scoped>
.page {
  margin: 1rem;
}
</style>

<script>

import {mapGetters} from "vuex"
import ShoppingCartItem from "@/components/ShoppingCartItem";

export default {
  name: 'ShoppingCart',
  components: {
    ShoppingCartItem
  },
  props: {
    items: [
      {
        id: Number,
        name: String,
        description: String,
        category: String,
        price: Number,
        count: Number
      }
    ]
  },
  computed: {
    ...mapGetters({
      menu: "getOrderItems",
      itemCount: "getOrderCount"
    })
  },
  methods: {
    Send() {
      this.$store.commit('setLoading', true);
      this.$store.dispatch('Send').then(() => {
        this.$store.commit('setLoading', false);
        this.$router.push({name: 'OrderConfirmation'});
      })
    }
  }
}
</script>

