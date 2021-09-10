<template>
  <div class="page">
    <div class="button primary" @click="navigate('Admin_Tables')">Tafels</div>
    <div class="button primary">Menu</div>
  </div>
</template>

<style scoped>
.page {
  margin: 1rem;
  text-align: center;
}
</style>

<script>
export default {
  name: 'Admin_Menu',
  methods:{
    async navigate(name) {
      await this.$router.push({name});
    },

  }
}

</script>