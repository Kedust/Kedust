<template>
  <div class="page">
    <div class="notification">
    Uw bestelling is verzonden en komt zo dadelijk aan
</div>
    <router-link class="button primary-bg" :to="{name: 'Menu'}">Nieuwe bestelling</router-link>

  </div>
</template>

<style scoped>
.page {
  margin: 1rem;
  text-align: center;
}
.notification{
  margin-bottom: 1rem;
}
</style>

<script>
export default {
  name: 'OrderConfirmation'
}

</script>