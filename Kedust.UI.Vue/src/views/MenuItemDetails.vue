<template>
  <div class="page">

    <div class="button back" @click="goToMenu"><i class="material-icons">arrow_back</i></div>

    <img class="picture" :src="currentMenuItem.image" :alt="currentMenuItem.name"/>

    <div>{{ currentMenuItem.name }}</div>
    <div>{{ currentMenuItem.description }}</div>

    <div class="flex-container z-depth-1-half">
      <div class="count-number">{{ currentMenuItem.count }}</div>

      <div class="flex-container">
        <span class="count-button" @click="decrement"><i class="material-icons">remove_circle_outline</i></span>
        <span class="count-button" @click="increment"><i class="material-icons">add_circle_outline</i></span>
      </div>
    </div>

    <div class="button primary-bg" @click="goToMenu">Bevestigen</div>

  </div>
</template>

<style scoped>

.page {
  margin: 1rem;
  text-align: center;
}

.flex-container {
  display: flex;
  justify-content: space-between;
}

.count-number {
  font-size: 2rem;
  margin: 0.5rem 2rem 0.5rem 1rem;
}

.count-button {
  padding: 0.75rem 1rem 0.5rem 1rem;
  margin: 0.5rem;
}

.back {
  position: absolute;
  top: 1rem;
  left: 1rem;
}

.button {
  margin-top: 1rem;
  display: block;
  padding: 1rem;
}

.picture {
  max-height: 20vh;
  max-width: 20vw;
  display: block;
  margin: 0 auto 1rem auto;
  color: black;
}
</style>

<script>

import {mapGetters, mapMutations} from "vuex";

export default {
  name: 'MenuItemDetails',
  props: {
    item: {
      id: Number,
      name: String,
      price: Number,
      description: String,
      image: String
    }
  },
  computed: {
    ...mapGetters(
        {
          currentMenuItem: "getCurrentMenuItem",
        }
    )
  },
  methods: {
    ...mapMutations({
      increment: "incrementCurrentOrderItem",
      decrement: "decrementCurrentOrderItem"
    }),
    goToMenu() {
      this.$router.push({name: 'Menu'})
    }
  }
}

</script>