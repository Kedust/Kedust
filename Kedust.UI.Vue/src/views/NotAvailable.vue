<template>
  <div class="page">
    <div class="notification">
      Sorry, momenteel kunnen er geen bestellingen opgenomen worden.<br>
      Probeer later opnieuw
    </div>
    <router-link class="button primary-bg" :to="{name: 'Menu'}">Opnieuw proberen</router-link>
  </div>
</template>

<style scoped>
.page {
  margin: 1rem;
  text-align: center;
}

.notification {
  margin-bottom: 1rem;
}
</style>

<script>
export default {
  name: 'NotAvailable'
}

</script>