<template>
  <div class="page">
    <div v-if="itemCount === 0">Er zit nog niets in je winkelmandje.</div>
    <div class="row">
      <ShoppingCartItem v-for="item in menu" :key="item.id" :item="item"/>
    </div>

    <div class="total-row">
      <span>Totaal</span>
      <span>{{ itemCount }} stuks</span>
      <span>{{ price }} €</span>
    </div>

    <router-link class="button primary" :to="{name: 'Menu'}">Menu</router-link>
    <div v-if="itemCount>0" class="button primary-bg" @click="Send">Verzenden</div>
  </div>
</template>

<style scoped>
.page {
  margin: 1rem;
}

.total-row {
  display: flex;
  justify-content: space-between;
}
</style>

<script>

import {mapActions, mapGetters, mapMutations} from "vuex"
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
      itemCount: "getOrderCount",
      price: "getOrderPrice"
    })
  },
  methods: {
    ...mapActions({
      sendOrder: "Send",
      updateMenu: "fetchMenu"
    }),
    ...mapMutations({
      loading: "setLoading"
    }),
    async Send() {
      this.loading(true);
      const success = await this.sendOrder()
      if (success) {
        await this.updateMenu()
        this.setLoading(false)
        await this.$router.push({name: 'OrderConfirmation'});
      } else {
        alert("er is iets fout gegaan, probeer later opnieuw alstublieft");
        this.loading(false);
      }
    }
  }
}
</script>

