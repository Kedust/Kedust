<template>
  <div class="menu-item border">
    <span>
      <div class="name">{{ item.name }}</div>
      <div>{{ item.description }}</div>
    </span>
    <span>
      <span><i class="material-icons border" @click="decrement(item.id)">remove_circle_outline</i></span>
      <span class="count">{{ item.count }}</span>
      <span><i class="material-icons border" @click="increment(item.id)">add_circle_outline</i></span>
    </span>
  </div>
</template>

<script>


import {mapMutations} from "vuex";

export default {
  name: 'ShoppingCartItem',
  methods: {
    ...mapMutations({
      increment: "incrementOrderItem",
      decrement: "decrementOrderItem"
    })
  },
  props: {
    item: {
      id: Number,
      name: String,
      price: Number,
      count: Number,
      description: String
    }
  }
}
</script>

<style scoped>

.material-icons {
  padding: 1rem;
}

.menu-item {
  display: flex;
  justify-content: space-between;
  margin-bottom: 1rem;
  padding: 1rem;
}

.name {
  font-weight: bold;
}

.count {
  font-weight: bold;
  font-size: 1.25rem;
  padding: 1rem;
}
</style>
