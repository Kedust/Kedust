<template >
  <div class="shopping-cart button" @click="OpenShoppingCart">
    <div class="flex-container">
      <span><i class="material-icons">shopping_cart</i></span>
      <span>{{itemCount}} stuks</span>
      <span>{{price}} vakjes</span>
    </div>
  </div>
</template>

<script>
import {mapGetters} from "vuex";

export default {
  name: 'ShoppingCartButton',
  computed:{
    ...mapGetters({
      itemCount: "getOrderCount",
      price: "getOrderPrice"
    })
  },
  methods: {
    OpenShoppingCart(){
      this.$router.push({name:'ShoppingCart'})
    }
  }
}
</script>

<style scoped>

.material-icons {
  vertical-align: top;
}

.flex-container {
  display: flex;
  justify-content: space-between;
}

.shopping-cart {
  font-size: 1.25rem;
  background-color: #26a69a;
  color: white;
  z-index: 0;
  position: fixed;
  left: 1rem;
  bottom: 1rem;
  right: 1rem;
  padding: 1rem;
}
</style>
