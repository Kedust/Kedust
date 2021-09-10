<template>
  <div class="page">
    <div class="back-button" @click="goToMenu"><i class="material-icons">arrow_back</i></div>

    last 3 orders
  </div>
</template>

<script>
export default {
  name: 'TableHistory',
  methods: {
    async goToMenu() {
      await this.$router.push({name: "Menu"})
    }
  }
}


</script>