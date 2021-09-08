<template>
  <div class="page">
    <div v-if="itemCount === 0">Er zit nog niets in je winkelmandje.</div>
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
    async Send() {
      this.$store.commit('setLoading', true);
      const success = await this.$store.dispatch('Send');
      if(success){
        await this.$store.dispatch('fetchMenu');
        this.$store.commit('setLoading', false);
        await this.$router.push({name: 'OrderConfirmation'});
      }
      else{
        alert("er is iets fout gegaan, probeer later opnieuw alstublieft")
        this.$store.commit('setLoading', false);
      }
    }
  }
}
</script>

