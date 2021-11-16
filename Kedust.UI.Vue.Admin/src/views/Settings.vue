<template>
  <h1>Instellingen</h1>
  <div>
    <button class="btn waves-effect btn-large" @click="BlockOrders(this.$store)"><i class="material-icons left">block</i>Alle
      bestellingen blokeren
    </button>
    <button class="btn waves-effect btn-large right" @click="EnableOrders(this.$store)"><i class="material-icons left">check</i>Bestellingen
      opnieuw toelaten
    </button>
  </div>
</template>

<script>
export default {
  name: "Orders",
  methods: {
    BlockOrders: (store) => {
      store.dispatch('setCanPlaceOrder', false);
    },
    EnableOrders: (store) => {
      store.dispatch('setCanPlaceOrder', true);
    }
  }
}
</script>

<style scoped>

</style>