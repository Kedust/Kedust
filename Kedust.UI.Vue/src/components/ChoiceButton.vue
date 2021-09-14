<template>
  <div class="menu-item border" @click="selectMenuItem(item)">
    <div class="flex-container">
      <span class="name">{{ item.name }}</span>
      <span class="price">{{ item.price.toFixed(2) }}</span>
    </div>
    <div class="flex-container">
      <span class="description">{{ item.description }}</span>
      <span class="count" v-if="item.count > 0">{{ item.count }} x</span>
    </div>
  </div>
</template>

<script>


import {mapMutations} from "vuex";

export default {
  name: 'ChoiceButton',
  props: {
    id: Number,
    item: {
      id: Number,
      name: String,
      price: Number,
      description: String
    }
  },
  methods: {
    ...mapMutations({
      currentMenuItem: "setCurrentMenuItem"
    }),
    async selectMenuItem(item){
      this.currentMenuItem(item)
      await this.$router.push({name:"Choice"});
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

.name{
  font-weight: bold;
}

.count{
  font-weight: bold;
  color: #26a69a;
}
</style>
