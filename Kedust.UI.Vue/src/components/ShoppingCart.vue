<template >
  <div class="shopping-cart z-depth-1-half">
    <div class="flex-container">
      <span>Op den plateau</span>
      <span class="nr-of-drinks">2</span>
    </div>
  </div>
</template>

<script>
export default {
  name: 'ShoppingCart'
}
</script>

<style scoped>
.flex-container {
  display: flex;
  justify-content: space-between;
}

.nr-of-drinks{
  background-color: white;
  color: #f0750f;
  border-radius: 1rem;
  padding: 1.5em;
}
.shopping-cart {
  font-size: larger;
  background-color: #f0750f;
  color: white;
  z-index: 0;
  position: fixed;
  left: 1rem;
  bottom: 1rem;
  right: 1rem;
  padding: 1rem;
}
</style>
