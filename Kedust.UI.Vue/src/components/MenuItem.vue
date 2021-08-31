<template>
  <router-link class="menu-item z-depth-1-half" :to="{ name: 'OrderItem', params: { id: item.id }}" tag="div">

    <div class="flex-container">
      <span class="name">{{ item.name }}</span>
      <span class="price">{{ item.price.toFixed(2) }}</span>
    </div>
    <div>
      <span class="description">{{ item.description }}</span>
    </div>

  </router-link>
</template>

<script>
export default {
  name: 'MenuItem',
  props: {
    id: Number,
    item: {
      id: Number,
      name: String,
      price: Number,
      description: String
    }
  }
}
</script>

<style scoped>
.flex-container {
  display: flex;
  justify-content: space-between;
}

.menu-item {
  margin-bottom: 1rem;
  padding: 1rem;
}
</style>
